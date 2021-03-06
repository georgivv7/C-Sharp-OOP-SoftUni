namespace Forum.App.Services
{
    using Contracts;
    using Forum.App.Contracts.ViewModels;
    using Forum.App.ViewModels;
    using Forum.Data;
    using Forum.DataModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PostService : IPostService
    {
        private ForumData forumData;
        private IUserService userService;

        public PostService(ForumData forumData, IUserService userService)
        {
            this.forumData = forumData;
            this.userService = userService;
        }
        public int AddPost(int authorId, string postTitle, string postCategory, string postContent)
        {
            User author = this.forumData.Users.FirstOrDefault(u => u.Id == authorId);

            if (author == null)
            {
                throw new System.ArgumentException($"User with ID {authorId} not found!");
            }

            int postId = this.forumData.Posts.LastOrDefault()?.Id + 1 ?? 1;
            Category category = this.EnsureCategory(postCategory);
            Post post = new Post(postId, postTitle, postContent, category.Id, authorId, new List<int>());

            this.forumData.Posts.Add(post);
            author.Posts.Add(postId);
            category.Posts.Add(postId);

            this.forumData.SaveChanges();
            return postId;
        }

        private Category EnsureCategory(string postCategory)
        {
            Category category = this.forumData.Categories.FirstOrDefault(c => c.Name == postCategory);

            if (category == null)
            {
                int categoryId = this.forumData.Categories.LastOrDefault()?.Id + 1 ?? 1;
                category = new Category(categoryId, postCategory, new List<int>());
            }

            return category;
        }

        public void AddReplyToPost(int postId, string replyContents, int userId)
        {
            Post post = this.forumData.Posts.Find(p => p.Id == postId);
            User author = this.userService.GetUserById(userId);

            int replyId = this.forumData.Replies.LastOrDefault()?.Id + 1 ?? 1;
            Reply reply = new Reply(replyId, replyContents, userId, postId);

            this.forumData.Replies.Add(reply);
            post.Replies.Add(replyId);
            this.forumData.SaveChanges(); 
        }

        public IEnumerable<ICategoryInfoViewModel> GetAllCategories()
        {
            IEnumerable<ICategoryInfoViewModel> categories = this.forumData.Categories
                .Select(c => new CategoryInfoViewModel(c.Id, c.Name, c.Posts.Count));

            return categories;
        }

        public string GetCategoryName(int categoryId)
        {
            string categoryName = this.forumData.Categories.Find(c => c.Id == categoryId)?.Name;

            if (categoryName == null)
            {
                throw new ArgumentException($"Category with id {categoryId} not found!");
            }

            return categoryName;
        }

        public IEnumerable<IPostInfoViewModel> GetCategoryPostsInfo(int categoryId)
        {
            IEnumerable<IPostInfoViewModel> posts = (IEnumerable<IPostInfoViewModel>)this.forumData.Posts
                .Where(p => p.Id == categoryId)
                .Select(p => new PostInfoViewModel(p.Id, p.Title, p.Replies.Count));

            return posts;
        }

        public IPostViewModel GetPostViewModel(int postId)
        {
            Post post = this.forumData.Posts.FirstOrDefault(p => p.Id == postId);

            if (post == null)
            {
                throw new ArgumentException($"Post with ID {postId} not found!");
            }

            string author = this.userService.GetUserName(post.AuthorId);

            IPostViewModel postViewModel = new PostViewModel(post.Title, author,
                post.Content, this.GetPostReplies(postId));

            return postViewModel;
        }

        private IEnumerable<IReplyViewModel> GetPostReplies(int postId)
        {
            IEnumerable<IReplyViewModel> replies = this.forumData.Replies.Where(r => r.PostId == postId)
                .Select(r => new ReplyViewModel(this.userService.GetUserName(r.AuthorId), r.Content));

            return replies;
        }
    }
}
