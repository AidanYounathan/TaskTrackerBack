using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTrackerBackend.Models;
using TaskTrackerBackend.Models.DTO;
using TaskTrackerBackend.Services.Context;

namespace TaskTrackerBackend.Services
{
    public class BoardService : ControllerBase
    {
        private readonly DataContext _context;
        public BoardService(DataContext context)
        {
            _context = context;
        }

        public UserModel GetUserByUsername(string username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username);
        }

        public BoardModel GetBoardModelByID(int id)
        {
            return _context.BoardInfo.SingleOrDefault(board => board.ID == id);
        }

        public bool AddBoardToUser(int id, string username)
        {
            UserModel foundUser = GetUserByUsername(username);
            BoardModel board = new BoardModel();
            foundUser.BoardInfo.Add(board);
            _context.Update<UserModel>(foundUser);
            return _context.SaveChanges() != 0;
        }

        public string CreateBoardID()
        {
            Random random = new Random();
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            string code = "";
            for(int i = 0; i < 3; i++){
                int index = random.Next(letters.Length);
                code += letters[index];
            }
            for(int i = 0; i < 3; i++){
                int index = random.Next(numbers.Length);
                code += numbers[index];
            }
            return code;
            
        }

        

        public List<BoardModel> GetAllBoards()
        {
            return _context.BoardInfo.ToList();
        }

        public IEnumerable<BoardModel> GetBoardModelsByUser(string username)
        {
            UserModel foundUser = GetUserByUsername(username);
            return _context.BoardInfo.Where(blog => blog.UserID == foundUser.ID);
        }

        public bool CreateBoard(CreateBoardDTO newBoard)
        {
            bool falseId = true;
            UserModel foundUser = GetUserByUsername(newBoard.Username);
            BoardModel createdBoard = new BoardModel();
            createdBoard.BoardName = newBoard.BoardName;
            createdBoard.Posts = new List<PostModel>();
            createdBoard.UserID = foundUser.ID;

            while (falseId)
            {
                bool newId = true;
                string id = CreateBoardID();
                List<BoardModel> boards = GetAllBoards();
                foreach (BoardModel board in boards)
                {
                    if (board.BoardID == id)
                    {
                        newId = false;
                    }
                }
                if (newId)
                {
                    createdBoard.BoardID = id;
                    falseId = false;
                }
            }

            _context.Add(createdBoard);

            return _context.SaveChanges() != 0;
        }

        public BoardModel GetBoardModelByID(string BoardID)
        {
            return _context.BoardInfo.SingleOrDefault(board => board.BoardID == BoardID);
        }

        public List<PostModel> GetPostsByBoardID(string BoardID)
        {
            BoardModel foundBoard = GetBoardModelByID(BoardID);

            return foundBoard.Posts;
        }
    }
}