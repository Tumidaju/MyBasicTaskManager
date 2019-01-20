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
        public void Save(bool IsExisting, TaskFullViewModel Task, string UserId)
        {
            using (_db)
            {
                if(IsExisting)
                {
                    var dataModel = _db.TASK.Where(x => x.ID == Task.Id).First();
                    dataModel.ID = Task.Id;
                    dataModel.NAME = Task.Name;
                    dataModel.DESCRIPTION = Task.Description;
                    dataModel.CARD_COLOR = Task.CardColor;
                    dataModel.FONT_COLOR = Task.FontColor;
                    dataModel.DEADLINE_DATE = Task.DeadlineDate;
                    dataModel.PROGRES = Task.Progres;
                    dataModel.CATEGORY_ID = Task.Category;
                    dataModel.RANK_ID = Task.Rank;
                    dataModel.STATUS_ID = Task.Status;
                }
                else
                {
                    var dataModel = new TASK()
                    {
                        NAME = Task.Name,
                        DESCRIPTION = Task.Description,
                        CARD_COLOR = Task.CardColor,
                        FONT_COLOR = Task.FontColor,
                        CREATION_DATE = DateTime.Now,
                        DEADLINE_DATE = Task.DeadlineDate,
                        PROGRES = Task.Progres,
                        CATEGORY_ID = Task.Category,
                        RANK_ID = Task.Rank,
                        STATUS_ID = Task.Status,
                        USER_ID=UserId
                    };
                    _db.TASK.Add(dataModel);
                }
                _db.SaveChanges();
            }
            
        }
        public void Delete(int Id)
        {
            using (_db)
            {
                var dataModel = _db.TASK.Where(x => x.ID == Id).First();
                _db.TASK.Remove(dataModel);
                _db.SaveChanges();
            }
        }
    }
}