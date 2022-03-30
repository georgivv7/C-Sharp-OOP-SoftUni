﻿namespace Forum.App.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;

	using Contracts;
    using Forum.App.Models;

    public class TextAreaFactory : ITextAreaFactory
	{
		public ITextInputArea CreateTextArea(IForumReader reader, int x, int y, bool isPost = true)
		{
			ITextInputArea area = new TextInputArea(reader, x, y, isPost);
			return area;
		}
	}
}
