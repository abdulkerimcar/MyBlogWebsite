﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class Message2Manager : IMessage2Service
	{
		IMessage2Dal _messageDal;
        public Message2Manager(IMessage2Dal message2Dal)
        {
			_messageDal = message2Dal;
        }
        public List<Message2> GetInboxListByWriter(int id)
		{
			return _messageDal.GetListWithMessageyByWriter(id);
		}

		public List<Message2> GetList()
		{
			return _messageDal.GetListAll();
		}

        public List<Message2> GetSendBoxListByWriter(int id)
        {
			return _messageDal.GetSendBoxWithMessageyByWriter(id);
        }

        public void TAdd(Message2 t)
		{
			_messageDal.Insert(t);
		}

		public void TDelete(Message2 t)
		{
			throw new NotImplementedException();
		}

		public Message2 TGetByID(int id)
		{
			return _messageDal.GetByID(id);
		}

		public void TUpdate(Message2 t)
		{
			throw new NotImplementedException();
		}
	}
}
