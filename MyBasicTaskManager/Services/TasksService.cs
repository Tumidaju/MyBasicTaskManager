using MyBasicTaskManager.Models;
using MyBasicTaskManager.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace MyBasicTaskManager.Services
{
    public class TasksService
    {
        private readonly DatabaseModel _db = new DatabaseModel();
        public List<TaskFull> GetAll(string UserId)
        {
            var model = _db.TASK.Where(x=>x.USER_ID== UserId).Select(x => new TaskFull()
            {
                Id = x.ID,
                Name = x.NAME,
                Description = x.DESCRIPTION,
                CardColor = x.CARD_COLOR,
                FontColor = x.FONT_COLOR,
                CreationDate = x.CREATION_DATE,
                DeadlineDate = x.DEADLINE_DATE,
                Progres = x.PROGRES,
                Category = new Category()
                {
                    Id=x.CATEGORY.ID,
                    Name=x.CATEGORY.NAME,
                    Color=x.CATEGORY.COLOR
                },
                Rank = new Rank()
                {
                    Id = x.RANK.ID,
                    Name = x.RANK.NAME,
                    Color = x.RANK.COLOR
                },
                Status = new Status()
                {
                    Id = x.STATUS.ID,
                    Name = x.STATUS.NAME,
                    Color = x.STATUS.COLOR
                },
            }).ToList();
            return model;
        }
        public TaskFull Get(int Id, string UserId)
        {
            var model = _db.TASK.Where(x => x.USER_ID == UserId && x.ID==Id).Select(x => new TaskFull()
            {
                Id = x.ID,
                Name = x.NAME,
                Description = x.DESCRIPTION,
                CardColor = x.CARD_COLOR,
                FontColor = x.FONT_COLOR,
                CreationDate = x.CREATION_DATE,
                DeadlineDate = x.DEADLINE_DATE,
                Progres = x.PROGRES,
                Category = new Category()
                {
                    Id = x.CATEGORY.ID,
                    Name = x.CATEGORY.NAME,
                    Color = x.CATEGORY.COLOR
                },
                Rank = new Rank()
                {
                    Id = x.RANK.ID,
                    Name = x.RANK.NAME,
                    Color = x.RANK.COLOR
                },
                Status = new Status()
                {
                    Id = x.STATUS.ID,
                    Name = x.STATUS.NAME,
                    Color = x.STATUS.COLOR
                },
            }).FirstOrDefault();
            return model;
        }
        public bool Save(bool IsExisting,TaskFull Task, string UserId)
        {
            return true;
        }
        public void Delete(int Id)
        {

        }
    }
}