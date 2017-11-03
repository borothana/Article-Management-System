using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCMS.Models;
using SCMS.Models.Interface;
using SCMS.Datas.DBContext;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web;
using System.Web.Mvc;
using SCMS.Models.ViewModels;

namespace SCMS.Datas
{
    public class SCMSRepositoryEF : ISCMS
    {
        SCMSDBContext _ctx = new SCMSDBContext();

        #region "Category"
        public List<Category> GetCategoryList()
        {
            return _ctx.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return GetCategoryList().FirstOrDefault(c => c.CategoryId == categoryId);
        }

        public int AddCategory(Category category)
        {
            _ctx.Categories.Add(category);
            _ctx.SaveChanges();
            return _ctx.Categories.Max(c => c.CategoryId);
        }

        public bool UpdateCategory(Category category)
        {
            _ctx.Entry(category).State = System.Data.Entity.EntityState.Modified;
            _ctx.SaveChanges();
            return true;
        }

        public bool DeleteCategory(int categoryId)
        {
            Category category = GetCategoryById(categoryId);
            if (category != null)
            {
                _ctx.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                _ctx.SaveChanges();
            }
            return true;
        }
        #endregion

        #region "Intimacy"
        public List<Intimacy> GetIntimacyList()
        {
            return _ctx.Intimacies.ToList();
        }

        public Intimacy GetIntimacyById(int intimacyId)
        {
            return GetIntimacyList().FirstOrDefault(i => i.IntimacyId == intimacyId);
        }
        public int AddIntimacy(Intimacy intimacy)
        {
            _ctx.Intimacies.Add(intimacy);
            _ctx.SaveChanges();
            return _ctx.Intimacies.Max(i => i.IntimacyId);
        }

        public bool UpdateIntimacy(Intimacy intimacy)
        {
            _ctx.Entry(intimacy).State = System.Data.Entity.EntityState.Modified;
            _ctx.SaveChanges();
            return true;
        }
        public bool DeleteIntimacy(int intimacyId)
        {
            Intimacy intimacy = GetIntimacyById(intimacyId);
            if (intimacy != null)
            {
                _ctx.Entry(intimacy).State = System.Data.Entity.EntityState.Deleted;
                _ctx.SaveChanges();
            }
            return true;
        }

        #endregion

        #region "Story"
        public List<Story> GetStoryList()
        {
            return _ctx.Stories.ToList();
        }

        public Story GetStoryById(int storyId)
        {
            return GetStoryList().FirstOrDefault(s => s.StroyId == storyId);
        }

        public int AddStory(StoryVM storyVM)
        {
            Story story = new Story
            {

                StroyId = storyVM.StroyId,
                CategoryId = storyVM.CategoryId,
                IntimacyId = storyVM.IntimacyId,
                Title = storyVM.Title,
                Content = storyVM.Content,
                HashtagWord = storyVM.HashtagWord,
                Picture = storyVM.Picture,
                NoView = storyVM.NoView,
                ApproveStatue = storyVM.ApproveStatue,
                UserId = storyVM.UserId,

                Category = storyVM.Category,
                Intimacy = storyVM.Intimacy,

                Hashtags = storyVM.Hashtags
            };

            _ctx.Stories.Add(story);
            _ctx.SaveChanges();

            //Working with Hashtag
            List<Story> tmpStory = new List<Story> { story };
            string[] tmpHashtag = storyVM.HashtagWord.Split();
            for (int i = 0; i < tmpHashtag.Length; i++)
            {
                if(!GetHashtagList().Any(h=>h.Description == tmpHashtag[i]))
                {
                    AddHastag(new Hashtag { Description = tmpHashtag[i], Stories = tmpStory });
                }
            }
            
            return _ctx.Stories.Max(s => s.StroyId);
        }

        public bool UpdateStory(StoryVM storyVM)
        {
            Story story = new Story
            {
                StroyId = storyVM.StroyId,
                CategoryId = storyVM.CategoryId,
                IntimacyId = storyVM.IntimacyId,
                Title = storyVM.Title,
                Content = storyVM.Content,
                HashtagWord = storyVM.HashtagWord,
                Picture = storyVM.Picture,
                NoView = storyVM.NoView,
                ApproveStatue = storyVM.ApproveStatue,
                UserId = storyVM.UserId,

                Category = storyVM.Category,
                Intimacy = storyVM.Intimacy,

                Hashtags = storyVM.Hashtags
            };
            _ctx.Entry(story).State = System.Data.Entity.EntityState.Modified;
            _ctx.SaveChanges();
            return true;
        }
        public bool DeleteStory(int storyId)
        {
            Story story = GetStoryById(storyId);
            if (story != null)
            {
                _ctx.Entry(story).State = System.Data.Entity.EntityState.Deleted;
                _ctx.SaveChanges();
            }
            return true;
        }


        #endregion

        #region "Comment"
        public List<Comment> GetCommentList()
        {
            return _ctx.Comments.ToList();
        }

        public Comment GetCommentById(int commentId)
        {
            return GetCommentList().FirstOrDefault(c => c.CommentId == commentId);
        }

        public List<Comment> GetCommentByStory(int storyId)
        {
            return GetCommentList().Where(c => c.StoryId == storyId).ToList();
        }

        public int AddComment(Comment comment)
        {
            _ctx.Comments.Add(comment);
            _ctx.SaveChanges();
            return _ctx.Comments.Max(c => c.CommentId);
        }

        public bool UpdateComment(Comment comment)
        {
            _ctx.Entry(comment).State = System.Data.Entity.EntityState.Modified;
            _ctx.SaveChanges();
            return true;
        }
        public bool DeleteCommentById(int commentId)
        {
            Comment comment = GetCommentById(commentId);
            if (comment != null)
            {
                _ctx.Entry(comment).State = System.Data.Entity.EntityState.Deleted;
                _ctx.SaveChanges();
            }
            return true;
        }

        public bool DeleteCommentByStory(int storyId)
        {
            List<Comment> comment = GetCommentByStory(storyId);
            if (comment.Any())
            {
                _ctx.Entry(comment).State = System.Data.Entity.EntityState.Deleted;
                _ctx.SaveChanges();
            }
            return true;
        }
        #endregion

        #region "Hashtag"
        public List<Hashtag> GetHashtagList()
        {
            return _ctx.Hashtags.ToList();
        }

        public Hashtag GetHashtagById(int hastagId)
        {
            return GetHashtagList().FirstOrDefault(h => h.HashtagId == hastagId);
        }

        public List<Hashtag> GetHashtagByStory(int storyId)
        {
            return GetHashtagList().Where(h => h.Stories.Any(s => s.StroyId == storyId)).ToList();
        }

        public int AddHastag(Hashtag hashtag)
        {
            _ctx.Hashtags.Add(hashtag);
            _ctx.SaveChanges();
            return _ctx.Hashtags.Max(h => h.HashtagId);
        }

        public bool UpdateHashtag(Hashtag hashtag)
        {
            _ctx.Entry(hashtag).State = System.Data.Entity.EntityState.Modified;
            _ctx.SaveChanges();
            return true;
        }

        public bool DeleteHashtagById(int hashtagId)
        {
            Hashtag hashtag = GetHashtagById(hashtagId);
            if (hashtag != null)
            {
                _ctx.Entry(hashtag).State = System.Data.Entity.EntityState.Deleted;
                _ctx.SaveChanges();
            }
            return true;
        }

        public bool DeleteHashtagByStory(int storyId)
        {
            List<Hashtag> hashtag = GetHashtagByStory(storyId);
            if (hashtag.Any())
            {
                _ctx.Entry(hashtag).State = System.Data.Entity.EntityState.Deleted;
                _ctx.SaveChanges();
            }
            return true;
        }

        #endregion

        #region "User"
        public List<User> GetUserList()
        {
            return _ctx.Users.ToList();
        }


        public List<User> GetUserListByRole(string role)
        {
            //Need Modify to get by role
            return GetUserList();
        }

        public User GetUserById(string userId)
        {
            return GetUserList().FirstOrDefault(u => u.Id == userId);
        }

        public User GetUserByUserName(string userName)
        {
            return GetUserList().FirstOrDefault(u => u.UserName == userName);
        }

        public string AddUser(User user, string role)
        {
            var userMgr = new UserManager<SCMS.Models.User>(new UserStore<SCMS.Models.User>(_ctx));

            //if user name or email not existed
            if (!userMgr.Users.Any(u => u.UserName == user.UserName))
            {
                user.IsActive = true;
                userMgr.Create(user);

                var tmpuser = userMgr.Users.Single(u => u.UserName == user.UserName);
                if (!tmpuser.Roles.Any(r => r.RoleId == role))
                {
                    userMgr.AddToRole(tmpuser.Id, role);
                    return tmpuser.Id;
                }
            }

            return "";
        }

        public async Task<bool> UpdateUser(User user)
        {
            var userMgr = new UserManager<User>(new UserStore<User>(_ctx));
            User userTmp = await userMgr.FindByIdAsync(user.Id);
            if (userTmp == null)
            {
                return false;
            }
            userTmp.UserName = user.UserName;
            userTmp.Email = user.Email;
            userTmp.Phone = user.Phone;
            userTmp.Quote = user.Quote;
            userTmp.ProfilePic = user.ProfilePic;
            var result = await userMgr.UpdateAsync(userTmp);
            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }

        public bool ChangePassword(string userId, string currentPassword, string newPassword)
        {
            var userMgr = new UserManager<User>(new UserStore<User>(_ctx));
            User user = userMgr.Find(userId, currentPassword);
            if (user != null)
            {
                user.PasswordHash = userMgr.PasswordHasher.HashPassword(newPassword);
                var result = userMgr.Update(user);
                return result.Succeeded;
            }
            return false;
        }

        //public async Task<bool> ChangePassword(string userId, string currentPassword, string newPassword)
        //{
        //    var userMgr = new UserManager<User>(new UserStore<User>(_ctx));
        //    User user = await userMgr.FindAsync(userId, currentPassword);
        //    if (user != null)
        //    {
        //        user.PasswordHash = userMgr.PasswordHasher.HashPassword(newPassword);
        //        var result = await userMgr.UpdateAsync(user);
        //        if (result.Succeeded)
        //        {
        //            return await Task.FromResult(true);
        //        }
        //    }
        //    return await Task.FromResult(false);
        //}

        public async Task<bool> DeactivateUser(string userName)
        {
            var userMgr = new UserManager<User>(new UserStore<User>(_ctx));
            User user = await userMgr.FindByNameAsync(userName);
            if (user == null)
            {
                return false;
            }
            user.IsActive = false;
            var result = await userMgr.UpdateAsync(user);
            return result.Succeeded;
        }


        public async Task<bool> ReactivateUser(string userName)
        {
            var userMgr = new UserManager<User>(new UserStore<User>(_ctx));
            User user = await userMgr.FindByNameAsync(userName);
            if (user == null)
            {
                return false;
            }
            user.IsActive = true;
            var result = await userMgr.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> DeleteUser(string userId)
        {
            var userMgr = new UserManager<User>(new UserStore<User>(_ctx));
            User user = await userMgr.FindByIdAsync(userId);
            var logins = user.Logins;
            var rolesForUser = await userMgr.GetRolesAsync(userId);

            using (var transaction = _ctx.Database.BeginTransaction())
            {
                foreach (var login in logins.ToList())
                {
                    await userMgr.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                }

                if (rolesForUser.Count() > 0)
                {
                    foreach (var item in rolesForUser.ToList())
                    {
                        // item should be the name of the role
                        var result = await userMgr.RemoveFromRoleAsync(user.Id, item);
                    }
                }

                await userMgr.DeleteAsync(user);
                transaction.Commit();
            }
            return true;
        }

        public async Task<bool> Login(string userId, string password)
        {
            var userMgr = HttpContext.Current.GetOwinContext().GetUserManager<UserManager<User>>();
            var user = userMgr.Find(userId, password);
            if (user != null)
            {
                var identity = userMgr.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                var authManager = HttpContext.Current.GetOwinContext().Authentication;
                authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);
                CurrentUser.User = user;
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }


        #endregion
    }
}