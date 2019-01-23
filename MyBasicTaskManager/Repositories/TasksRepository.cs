﻿using MyBasicTaskManager.Models;
using MyBasicTaskManager.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace MyBasicTaskManager.Repositories
{
    public class TasksRepository
    {
        private readonly DatabaseModel _db = new DatabaseModel();
        private readonly StatisticsRepository _statisticsRepository = new StatisticsRepository();
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
                EditDate = x.LAST_EDIT_DATE,
                CompletionDate = x.COMPLETION_DATE,
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
                EditDate = x.LAST_EDIT_DATE,
                CompletionDate = x.COMPLETION_DATE,
                Progres = x.PROGRES,
                Category = new Category()
                {
                    Id = x.CATEGORY_ID,
                    Name = x.CATEGORY.NAME,
                    Color = x.CATEGORY.COLOR
                },
                Rank = new Rank()
                {
                    Id = x.RANK_ID,
                    Name = x.RANK.NAME,
                    Color = x.RANK.COLOR
                },
                Status = new Status()
                {
                    Id = x.STATUS_ID,
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
                    var dataModel = _db.TASK.Where(x => x.ID == Task.Id && x.USER_ID== UserId).First();
                    var previousStatus = dataModel.STATUS_ID;
                    var previousDeadline = dataModel.DEADLINE_DATE;

                    dataModel.ID = Task.Id;
                    dataModel.NAME = Task.Name;
                    dataModel.DESCRIPTION = Task.Description;
                    dataModel.CARD_COLOR = Task.CardColor;
                    dataModel.FONT_COLOR = Task.FontColor;
                    dataModel.DEADLINE_DATE = Task.DeadlineDate;
                    dataModel.LAST_EDIT_DATE = DateTime.Now;
                    if (Task.Status == 4)
                        dataModel.COMPLETION_DATE = DateTime.Now;
                    else
                        dataModel.COMPLETION_DATE = null;
                    dataModel.PROGRES = Task.Progres;
                    dataModel.CATEGORY_ID = Task.Category;
                    dataModel.RANK_ID = Task.Rank;
                    dataModel.STATUS_ID = Task.Status;
                    if (_db.SaveChanges() > 0)
                    {
                        if (previousStatus != 4 && Task.Status == 4)
                            _statisticsRepository.SetFinishedTasks(UserId, 1);
                        if (previousStatus == 4 && Task.Status != 4)
                            _statisticsRepository.SetFinishedTasks(UserId, -1); 
                        if (previousDeadline == null && Task.DeadlineDate != null)
                            _statisticsRepository.SetTasksWithDeadline(UserId, 1);
                        if (previousDeadline != null && Task.DeadlineDate == null)
                            _statisticsRepository.SetTasksWithDeadline(UserId, -1);
                        if (Task.DeadlineDate != null && Task.DeadlineDate>DateTime.Now && Task.Status == 4)
                            _statisticsRepository.SetTasksFinishedBeforeDeadline(UserId, 1);
                        if (Task.DeadlineDate != null && Task.DeadlineDate > DateTime.Now && previousStatus == 4 && Task.Status != 4 )
                            _statisticsRepository.SetTasksFinishedBeforeDeadline(UserId, -1);
                    }
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
                    if (Task.Status == 4)
                        dataModel.COMPLETION_DATE = DateTime.Now;
                    _db.TASK.Add(dataModel);
                    if (_db.SaveChanges() > 0)
                    {
                        _statisticsRepository.SetCreatedTasks(UserId);
                        _statisticsRepository.SetLastTaskCreation(UserId);
                        if (Task.DeadlineDate != null)
                            _statisticsRepository.SetTasksWithDeadline(UserId, 1);
                    }
                }
            }
            
        }
        public void Delete(int Id, string UserId)
        {
            using (_db)
            {
                var dataModel = _db.TASK.Where(x => x.ID == Id && x.USER_ID == UserId).First();
                _db.TASK.Remove(dataModel);
                if (_db.SaveChanges() > 0)
                {
                    _statisticsRepository.SetDeletedTasks(UserId);
                }
            }
        }
        public void ClearData(string UserId)
        {
            using (_db)
            {
                var model = _db.TASK.Where(x => x.USER_ID == UserId).ToList();
                if (model != null)
                {
                    _db.TASK.RemoveRange(model);
                }
                _db.SaveChanges();
            }
        }
    }
}