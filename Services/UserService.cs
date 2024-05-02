using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TaskTrackerBackend.Models;
using TaskTrackerBackend.Models.DTO;
using TaskTrackerBackend.Services.Context;

namespace TaskTrackerBackend.Services
{
    public class UserService : ControllerBase
    {
        

        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public bool DoesUserExist(string Username)
        {
            return _context.UserInfo.SingleOrDefault(User => User.Username == Username) != null;
        }

        public string GenerateImgID()
        {
           Random random = new Random();

            
        
            
            const string hexDigits = "0123456789ABCDEF";
            string code = "";
           for(int i = 0; i < 3; i++){
                int index = random.Next(hexDigits.Length);
                code += hexDigits[index];
            }

            return "#" + code;
        

        


        } 
        


        public bool CreateUser(CreateAccountDTO UserToAdd)
        {
            bool result = false;

            if(!DoesUserExist(UserToAdd.Username))
            {
                UserModel newUser = new UserModel();

                var hashPassword = HashPassword(UserToAdd.Password);
                
                    newUser.ID = UserToAdd.ID;

                    newUser.Username = UserToAdd.Username;   
                    newUser.Password = "";
                    newUser.Salt = hashPassword.Salt;
                    newUser.Hash = hashPassword.Hash;  
                    newUser.AccountCreated = true;
                    newUser.BoardInfo = new List<BoardModel>();
                    newUser.ProfileImg = UserToAdd.ProfileImg;


                    _context.Add(newUser);

                    result = _context.SaveChanges() != 0;  
                    result = true;    
            }

            return result;
        }


        public PasswordDTO HashPassword(string Password)
        {

            PasswordDTO NewHashPassword = new PasswordDTO();

            byte[] SaltBytes = new byte[64];
            
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();

            provider.GetNonZeroBytes(SaltBytes);

            string salt = Convert.ToBase64String(SaltBytes);

            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 1000);

            string hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            NewHashPassword.Salt = salt;
            NewHashPassword.Hash = hash;

            return NewHashPassword;

        }

        public bool VerifyPassword(string Password, string StoredHash, string StoredSalt)
        {
            byte[] SaltBytes = Convert.FromBase64String(StoredSalt);

            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 1000);

            string NewHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            return NewHash == StoredHash;

        }

        public IActionResult Login(LoginDTO User)
        {
            IActionResult Result = Unauthorized();

            if(DoesUserExist(User.Username))
            {

                UserModel foundUser = GetUserByUsername(User.Username);

                if(VerifyPassword(User.Password, foundUser.Hash, foundUser.Salt)){

                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var tokenOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5000",
                        audience: "http://localhost:5000",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signinCredentials
                    );
                    
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);


                    Result = Ok(new { Token = tokenString});
                }
            }
            return Result;
        }

        public UserModel GetUserByUsername(string username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username);
        }

        public List<BoardModel> GetBaordById(string BoardID)
        {
            return _context.BoardInfo.Where(board => board.BoardID == BoardID).ToList();
        }


        public bool UpdateUser(UserModel userToUpdate)
        {
            _context.Update<UserModel>(userToUpdate);
            return _context.SaveChanges() !=0 ;
        }

            public bool UpdateProfileImg(int id, string profileImg)
        {   
            UserModel foundUser = GetUserById(id);

             bool result = false;
             if(foundUser != null)
             {
                foundUser.ProfileImg = profileImg;
                _context.Update<UserModel>(foundUser);
                result = _context.SaveChanges() !=0 ;
             }
             return result;
        }

        public bool UpdateUsername(int id, string username)
        {
            UserModel foundUser = GetUserById(id);

            bool result = false;
             if(foundUser != null)
             {
                foundUser.Username = username;
                _context.Update<UserModel>(foundUser);
                result = _context.SaveChanges() !=0 ;
             }
             return result;

        }

        public UserModel GetUserById(int id)
        {
            return _context.UserInfo.SingleOrDefault(user => user.ID == id);
        }

        
        public bool DeleteUser(string userToDelete)
        {
            

            UserModel foundUser = GetUserByUsername(userToDelete);

            bool result = false;

            if (foundUser != null)
            {
               

                _context.Remove<UserModel>(foundUser);
                result = _context.SaveChanges() != 0;
            }

            return result;
        }

        public UserIdDTO GetUserIdDTOByUsername(string username)
        {
            UserIdDTO UserInfo = new UserIdDTO();

            
            UserModel foundUser = _context.UserInfo.SingleOrDefault(user => user.Username == username);

            UserInfo.UserId = foundUser.ID;

           
            UserInfo.PublisherName = foundUser.Username;

            return UserInfo;
        }





    }
}