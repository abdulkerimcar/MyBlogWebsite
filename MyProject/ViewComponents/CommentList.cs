using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MyProject.ViewComponents
{
	public class CommentList: ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var commentvalues = new List<UserComment>
			{
				new UserComment
				{
					ID=1,
					Username="Abdülkerim"
				},
				new UserComment
				{
					ID=2,
					Username="Sinan"
				},
				new UserComment
				{
					ID=3,
					Username="Ahmet"
				}

			};
			return View(commentvalues);
		}
	}
}
