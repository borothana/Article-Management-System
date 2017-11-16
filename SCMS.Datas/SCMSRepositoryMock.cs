using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCMS.Models;
using SCMS.Models.Interface;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Runtime.Remoting.Contexts;
using SCMS.Models.ViewModels;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.IO;

namespace SCMS.Datas
{
    public class SCMSRepositoryMock : ISCMS
    {

        static List<User> _users = new List<User>
        {
            new User { Id = "f9095c91-400e-4519-b844-7217afed26b9", UserName = "scms", Nickname = "scms", Email = "scms@gmail.com", PasswordHash = "12345678", IsActive = true },
            new User { Id = "a6fbd5b9-a1a9-4cf0-a060-758f2c066121", UserName = "member", Nickname = "Na", Email = "na@gmail.com", PasswordHash = "12345678", IsActive = true },
            new User { Id = "Nik", UserName = "Nik", Nickname = "Nik", Email = "nik@gmail.com", PasswordHash = "123456", IsActive = false },
            new User { Id = "Javier", UserName = "Javier", Nickname = "Javier", Email = "javier@gmail.com", PasswordHash = "123456" , IsActive = true}
        };

        static List<Info> _infos = new List<Info>
        {
            new Info{ InfoId = 1, Title = "11111", FDate = DateTime.Parse("11/01/2017"), TDate = DateTime.Parse("11/10/2017"), Description = "Description for 11111" },
            new Info{ InfoId = 2, Title = "22222", FDate = DateTime.Parse("11/15/2017"), TDate = DateTime.Parse("12/11/2017"), Description = "Description for 22222" },
            new Info{ InfoId = 3, Title = "33333", FDate = DateTime.Parse("10/01/2017"), TDate = DateTime.Parse("12/01/2017"), Description = "Description for 33333" },
            new Info{ InfoId = 4, Title = "44444", FDate = DateTime.Parse("12/25/2017"), TDate = DateTime.Parse("01/31/2018"), Description = "Description for 44444" },
            new Info{ InfoId = 5, Title = "55555", FDate = DateTime.Parse("11/15/2017"), TDate = DateTime.Parse("11/30/2018"), Description = "Description for 55555" }
        };


        static List<Category> _categories = new List<Category>
        {
            new Category{ CategoryId = 1, Description = "Food" },
            new Category{ CategoryId = 2, Description = "Love" },
            new Category{ CategoryId = 3, Description = "Culture" },
            new Category{ CategoryId = 4, Description = "Science" },
            new Category{ CategoryId = 5, Description = "Bedtime Story" }
        };

        static List<Intimacy> _intimacies = new List<Intimacy>
        {
            new Intimacy{ IntimacyId = 1, Description = "Low"},
            new Intimacy{ IntimacyId = 2, Description = "Medium"},
            new Intimacy{ IntimacyId = 3, Description = "High"}
        };

        static List<Story> _stories = new List<Story> {
            new Story{StoryId = 1, CategoryId = _categories[0].CategoryId, Category = _categories[0],  Title = "How to make a creemy cubcake",
                        Content = "Creemy cubcake blah blah blah....", IntimacyId = _intimacies[0].IntimacyId, Intimacy = _intimacies[0], Picture = null,
                        ApproveStatus = "Y", NoView = 1000, UserId = _users[0].Id, HashtagWord = "#cubcake #yummy",
                        Hashtags = new List<Hashtag>(){ new Hashtag() { HashtagId = 1, Description = "#cubcake" },  new Hashtag() { HashtagId = 2, Description = "#yummy" }}},
            new Story{StoryId = 2, CategoryId = _categories[1].CategoryId, Category = _categories[1],  Title = "My love story",
                        Content = "When I first meet her....", IntimacyId = _intimacies[1].IntimacyId, Intimacy = _intimacies[1], Picture = null,
                        ApproveStatus = "Y", NoView = 5000, UserId = _users[0].Id, HashtagWord = "#love #sweetevening",
                        Hashtags = new List<Hashtag>(){ new Hashtag() { HashtagId = 3, Description = "#love" },  new Hashtag() { HashtagId = 4, Description = "#sweetevening" }}},
            new Story{StoryId = 3, CategoryId = _categories[2].CategoryId, Category = _categories[2],  Title = "Angkor Wat",
                        Content = "In 11th century....", IntimacyId = _intimacies[2].IntimacyId, Intimacy = _intimacies[2], Picture = null,
                        ApproveStatus = "Y", NoView = 1000, UserId = _users[0].Id, HashtagWord = "#temple #ancient",
                        Hashtags = new List<Hashtag>(){ new Hashtag() { HashtagId = 5, Description = "#temple" },  new Hashtag() { HashtagId = 6, Description = "#ancient" }}},
            new Story{StoryId = 4, CategoryId = _categories[3].CategoryId, Category = _categories[3],  Title = "Discover Mars",
                        Content = "A group of scientist from USA, Russia and China....", IntimacyId = _intimacies[2].IntimacyId, Intimacy = _intimacies[2], Picture = null,
                        ApproveStatus = "Y", NoView = 1000, UserId = _users[0].Id, HashtagWord = "#colony #newlife",
                        Hashtags = new List<Hashtag>(){ new Hashtag() { HashtagId = 7, Description = "#colony" },  new Hashtag() { HashtagId = 7, Description = "#newlife" }}},
            new Story{StoryId = 5, CategoryId = _categories[4].CategoryId, Category = _categories[4],  Title = "Mr and Mrs Poor",
                        Content = "Once upon time....", IntimacyId = _intimacies[1].IntimacyId, Intimacy = _intimacies[1], Picture = null,
                        ApproveStatus = "Y", NoView = 1000, UserId = _users[0].Id, HashtagWord = "#bedtime #cartoon",
                        Hashtags = new List<Hashtag>(){ new Hashtag() { HashtagId = 9, Description = "#bedtime" },  new Hashtag() { HashtagId = 10, Description = "#cartoon" }}},

        };
        static List<Hashtag> _hashtags = new List<Hashtag> {
                new Hashtag{ HashtagId = 1, Description = "yummy", Stories = _stories},
                new Hashtag{ HashtagId = 2, Description = "sweet", Stories = _stories},
                new Hashtag{ HashtagId = 3, Description = "thousandyear", Stories = _stories},
                new Hashtag{ HashtagId = 4, Description = "Mars", Stories = _stories},
                new Hashtag{ HashtagId = 5, Description = "fly", Stories = _stories}
        };
        
        static List<Comment> _comments = new List<Comment> {
                new Comment{ CommentId =1, Descriptiopn = "Such a great story", StoryId = 1, Story = _stories[1]},
                new Comment{ CommentId =2, Descriptiopn = "Yeah, that's so romantic", StoryId = 1, Story = _stories[1]},
                new Comment{ CommentId =3, Descriptiopn = "We'll be able to live on Mars soon", StoryId = 4, Story = _stories[4]},
                new Comment{ CommentId =4, Descriptiopn = "I've been there one time, it's amazing", StoryId = 3, Story = _stories[3]},
                new Comment{ CommentId =5, Descriptiopn = "I will visit there one time", StoryId = 3, Story = _stories[3]},
        };
        static List<Blog> _blogs = new List<Blog>
        {
            new Blog{ BlogId = 1, Title= "First Blog", Content= "This is the first blog", User = _users[0], UserId = _users[0].Id},
            new Blog{ BlogId = 2, Title= "Second Blog", Content= "This is the second blog", User = _users[0], UserId = _users[0].Id},
            new Blog{ BlogId = 3, Title= "Third Blog", Content= "This is the third blog", User = _users[0], UserId = _users[0].Id}
        };

        #region "Other"
        public Response ReturnSuccess()
        {
            return new Response() { Success = true, ErrorMessage = "" };
        }

        public byte[] ConvertImgToByte(HttpPostedFileBase file)
        {
            byte[] imageByte = null;
            BinaryReader rdr = new BinaryReader(file.InputStream);
            imageByte = rdr.ReadBytes((int)file.ContentLength);
            return imageByte;
        }

        public bool Login(string userName, string password)
        {
            if (_users.Any(u => u.UserName == userName && u.PasswordHash == password))
            {
                var userMgr = HttpContext.Current.GetOwinContext().GetUserManager<UserManager<User>>();
                //User user = _users.FirstOrDefault(u => u.UserName == userName);
                User user = userMgr.Find(userName, password);
                if (user != null && user.IsActive == true)
                {
                    var identity = userMgr.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    var authManager = HttpContext.Current.GetOwinContext().Authentication;
                    authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);
                    CurrentUser.User = user;
                    return true;
                }
            }
            return false;
        }

        public bool Logout()
        {
            var ctx = HttpContext.Current.GetOwinContext();
            var authMgr = ctx.Authentication;
            authMgr.SignOut("ApplicationCookie");

            return true;
        }

        #endregion

        #region "Infos"
        public List<Info> GetCurrentInfo() {
            return GetInfoList().Where(i => i.FDate <= DateTime.Now.Date && i.TDate >= DateTime.Now.Date).ToList();
        }

        public List<Info> GetInfoByDate(DateTime FD, DateTime TD)
        {
            return GetInfoList().Where(n => n.FDate >= FD && n.TDate <= TD).ToList();
        }

        public Info GetInfoById(int InfoId)
        {
            return GetInfoList().FirstOrDefault(n => n.InfoId == InfoId);
        }

        public List<Info> GetInfoList()
        {
            return _infos;
        }

        public int AddInfo(Info news)
        {
            if (_infos.Count <= 0)
            {
                news.InfoId = 1;
            }
            else
            {
                news.InfoId = _infos.Max(n => n.InfoId) + 1;
            }
            _infos.Add(news);
            return news.InfoId;
        }

        public bool UpdateInfo(Info news)
        {
            _infos.RemoveAll(n => n.InfoId == news.InfoId);
            _infos.Add(news);
            return true;
        }

        public bool DeleteInfo(int InfoId)
        {
            _infos.RemoveAll(n => n.InfoId == InfoId);
            return true;
        }
        #endregion

        #region "Category"
        public List<Category> GetCategoryList()
        {
            return _categories;
        }
     
        public int AddCategory(Category category)
        {
            if (_categories.Count <= 0)
            {
                category.CategoryId = 1;
            }
            else
            {
                category.CategoryId = _categories.Max(c => c.CategoryId) + 1;
            }
            _categories.Add(category);
            return category.CategoryId;
        }

        public bool UpdateCategory(Category category)
        {
            _categories.RemoveAll(c => c.CategoryId == category.CategoryId);
            _categories.Add(category);
            return true;
        }

        public bool DeleteCategory(int categoryId)
        {
            _categories.RemoveAll(c => c.CategoryId == categoryId);
            return true;
        }

        public Category GetCategoryById(int categoryId)
        {
            return GetCategoryList().FirstOrDefault(c => c.CategoryId == categoryId);
        }

        public List<CategoryVM> GetCategoryVMList()
        {
            List<CategoryVM> result = new List<CategoryVM>();
            List<Category> categories = GetCategoryList();
            foreach(Category c in categories)
            {
                result.Add(new CategoryVM()
                {
                    Category = new Category() { CategoryId = c.CategoryId, Description = c.Description},
                    IsSelected = false
                });
            }
            return result;
        }

        #endregion

        #region "Intimacy"
        public List<Intimacy> GetIntimacyList()
        {
            return _intimacies;
        }
        
        public int AddIntimacy(Intimacy intimacy)
        {
            if (_intimacies.Count <= 0)
            {
                intimacy.IntimacyId = 1;
            }
            else
            {
                intimacy.IntimacyId = _intimacies.Max(c => c.IntimacyId) + 1;
            }
            _intimacies.Add(intimacy);
            return intimacy.IntimacyId;
        }

        public bool UpdateIntimacy(Intimacy intimacy)
        {
            _intimacies.RemoveAll(i => i.IntimacyId == intimacy.IntimacyId);
            _intimacies.Add(intimacy);
            return true;
        }
        public bool DeleteIntimacy(int intimacyId)
        {
            _intimacies.RemoveAll(i => i.IntimacyId == intimacyId);
            return true;
        }

        public Intimacy GetIntimacyById(int itimacyId)
        {
            return _intimacies.FirstOrDefault(i => i.IntimacyId == itimacyId);
        }

        public List<IntimacyVM> GetIntimacyVMList()
        {
            List<IntimacyVM> result = new List<IntimacyVM>();
            List<Intimacy> intimacies = GetIntimacyList();
            foreach (Intimacy i in intimacies)
            {
                result.Add(new IntimacyVM()
                {
                    Intimacy = new Intimacy() { IntimacyId = i.IntimacyId, Description = i.Description },
                    IsSelected = false
                });
            }
            return result;
        }
        #endregion

        #region "Story"
        public List<Story> GetStoryList()
        {
            return _stories;
        }
        
        public int AddStory(StoryVM storyVM)
        {
            if (_stories.Count <= 0)
            {
                storyVM.StoryId = 1;
            }
            else
            {
                storyVM.StoryId = _stories.Max(c => c.StoryId) + 1;
            }
            Story story = new Story
            {
                StoryId = storyVM.StoryId,
                CategoryId = storyVM.CategoryId,
                IntimacyId = storyVM.IntimacyId,
                Title = storyVM.Title,
                Content = storyVM.Content,
                HashtagWord = storyVM.HashtagWord,
                Picture = storyVM.Picture,
                NoView = storyVM.NoView,
                ApproveStatus = "P",
                UserId = storyVM.UserId,

                Category = GetCategoryById(storyVM.CategoryId),
                Intimacy = GetIntimacyById(storyVM.IntimacyId),

                Hashtags = storyVM.Hashtags
            };
            _stories.Add(story);
            return story.StoryId;
        }

        public bool UpdateStory(StoryVM storyVM)
        {
            Story story = new Story
            {

                StoryId = storyVM.StoryId,
                CategoryId = storyVM.CategoryId,
                IntimacyId = storyVM.IntimacyId,
                Title = storyVM.Title,
                Content = storyVM.Content,
                HashtagWord = storyVM.HashtagWord,
                Picture = storyVM.Picture,
                NoView = storyVM.NoView,
                ApproveStatus = "P",
                UserId = storyVM.UserId,

                Category = GetCategoryById(storyVM.CategoryId),
                Intimacy = GetIntimacyById(storyVM.IntimacyId),

                Hashtags = storyVM.Hashtags
            };
            _stories.RemoveAll(s => s.StoryId == story.StoryId);
            _stories.Add(story);
            return true;
        }

        public bool ApproveStory(int storyId, string feedback)
        {
            Story story = GetStoryById(storyId);
            story.ApproveStatus = "Y";
            story.Feedback = feedback;
            _stories.RemoveAll(s => s.StoryId == story.StoryId);
            _stories.Add(story);
            return true;
        }

        public bool DenyStory (int storyId, string feedback)
        {
            Story story = GetStoryById(storyId);
            story.Feedback = feedback;
            story.ApproveStatus = "N";
            _stories.RemoveAll(s => s.StoryId == story.StoryId);
            _stories.Add(story);
            return true;
        }

        public bool DeleteStory(int storyId)
        {
            _stories.RemoveAll(s => s.StoryId == storyId);
            return true;
        }

        public List<Story> GetStoryForHome(List<int> categorySelected, List<int> intimacySelected, string userName, string title, string hashTag)
        {
            string[] hash = hashTag.Split();

            List<StoryVM> tmp = (from s in GetStoryVMList().Where(s => s.ApproveStatus == "Y")
                                 where (categorySelected.Count > 0 ? categorySelected.Contains(s.CategoryId) : true) &&
                                   (intimacySelected.Count > 0 ? intimacySelected.Contains(s.IntimacyId) : true) &&
                                   (!string.IsNullOrEmpty(title) ? s.Title.Contains(title) : true) &&
                                   (!string.IsNullOrEmpty(userName) ? s.User.Nickname.Contains(userName) : true) &&
                                   (!string.IsNullOrEmpty(hashTag) && hash.Length > 0 ? s.Hashtags.Any(h => hash.Contains(h.Description)) : true)
                                 select s).ToList();

            List<Story> result = new List<Story>();
            foreach (StoryVM s in tmp)
            {
                result.Add(ConvertVMToStory(s));
            }
            return result;
        }

        public List<StoryVM> GetStoryByStatus(string status)
        {
            List<StoryVM> result = new List<StoryVM>();
            List<Story> story = GetStoryList().Where(s => s.ApproveStatus == status).ToList();
            foreach (Story s in story)
            {
                result.Add(ConvertStoryToVM(s));
            }
            return result;
        }

        public List<Story> GetStoryByUserId(string userId)
        {
            return GetStoryList().Where(s => s.UserId == userId).ToList();
        }

        public Story GetStoryById(int storyId)
        {
            return GetStoryList().FirstOrDefault(s => s.StoryId == storyId);
        }

        public List<StoryVM> GetStoryVMList()
        {
            List<Story> story = GetStoryList();
            List<StoryVM> storyVM = new List<StoryVM>();
            foreach (Story s in story)
            {
                storyVM.Add(ConvertStoryToVM(s));
            }
            return storyVM;
        }

        public StoryVM GetStoryVMById(int storyId)
        {
            Story story = GetStoryList().FirstOrDefault(s => s.StoryId == storyId);
            return ConvertStoryToVM(story);
        }

        public StoryVM ConvertStoryToVM(Story story)
        {
            StoryVM storyVM = new StoryVM
            {

                StoryId = story.StoryId,
                CategoryId = story.CategoryId,
                IntimacyId = story.IntimacyId,
                Title = story.Title,
                Content = story.Content,
                HashtagWord = story.HashtagWord,
                Picture = story.Picture,
                NoView = story.NoView,
                ApproveStatus = story.ApproveStatus,
                UserId = story.UserId,

                Category = GetCategoryById(story.CategoryId),
                Intimacy = GetIntimacyById(story.IntimacyId),
                User = GetUserById(story.UserId),
                Hashtags = story.Hashtags
            };

            return storyVM;
        }

        public Story ConvertVMToStory(StoryVM storyVM)
        {
            Story story = new Story
            {

                StoryId = storyVM.StoryId,
                CategoryId = storyVM.CategoryId,
                IntimacyId = storyVM.IntimacyId,
                Title = storyVM.Title,
                Content = storyVM.Content,
                HashtagWord = storyVM.HashtagWord,
                Picture = storyVM.Picture,
                NoView = storyVM.NoView,
                ApproveStatus = storyVM.ApproveStatus,
                UserId = storyVM.UserId,

                Category = GetCategoryById(storyVM.CategoryId),
                Intimacy = GetIntimacyById(storyVM.IntimacyId),

                Hashtags = storyVM.Hashtags
            };
            return story;
        }

        public List<StoryVM> GetStoryVMByUserId(string userId)
        {
            List<StoryVM> result = new List<StoryVM>();
            List<Story> story = GetStoryList().Where(s => s.UserId == userId).ToList();
            foreach (Story s in story)
            {
                result.Add(ConvertStoryToVM(s));
            }
            return result;
        }
        #endregion

        #region "Comment"
        public List<Comment> GetCommentList()
        {
            return _comments;
        }

        public Comment GetCommentById(int commentId)
        {
            return _comments.FirstOrDefault(c => c.CommentId == commentId);
        }

        public List<Comment> GetCommentByStory(int storyId)
        {
            return _comments.Where(c => c.StoryId == storyId).ToList();
        }

        public int AddComment(Comment comment)
        {
            if (_comments.Count <= 0)
            {
                comment.CommentId = 1;
            }
            else
            {
                comment.CommentId = _comments.Max(c => c.CommentId) + 1;
            }
            _comments.Add(comment);
            return comment.CommentId;
        }

        public bool UpdateComment(Comment comment)
        {
            _comments.RemoveAll(c => c.CommentId == comment.CommentId);
            _comments.Add(comment);
            return true;
        }
        public bool DeleteCommentById(int commentId)
        {
            _comments.RemoveAll(c => c.CommentId == commentId);
            return true;
        }

        public bool DeleteCommentByStory(int storyId)
        {
            _comments.RemoveAll(c => c.StoryId == storyId);
            return true;
        }
        #endregion

        #region "Hashtag"
        public List<Hashtag> GetHashtagList()
        {
            return _hashtags;
        }

        public int AddHashtag(Hashtag hashtag)
        {
            if (_hashtags.Count <= 0)
            {
                hashtag.HashtagId = 1;
            }
            else
            {
                hashtag.HashtagId = _hashtags.Max(h => h.HashtagId) + 1;
            }
            _hashtags.Add(hashtag);
            return hashtag.HashtagId;
        }

        public bool AddHashtagByStory(Story story)
        {
            string[] tmpHashtag = story.HashtagWord.Split();
            for (int i = 0; i < tmpHashtag.Length; i++)
            {
                if (tmpHashtag[i].Trim() == "") continue;

                Hashtag hashtag;
                if (!GetHashtagList().Any(h => h.Description == tmpHashtag[i]))
                {
                    hashtag = new Hashtag { Description = tmpHashtag[i] };
                    hashtag.Stories.Add(story);
                    _hashtags.Add(hashtag);
                }
                else
                {
                    hashtag = GetHashtagList().FirstOrDefault(h => h.Description == tmpHashtag[i]);
                    hashtag.Stories.Add(story);                    
                }
            }

            return true;
        }

        public bool UpdateHashtag(Hashtag hashtag)
        {
            _hashtags.RemoveAll(h => h.HashtagId == hashtag.HashtagId);
            _hashtags.Add(hashtag);
            return true;
        }

        public bool DeleteHashtagById(int hashtagId)
        {
            _hashtags.RemoveAll(h => h.HashtagId == hashtagId);
            return true;
        }

        public bool DeleteHashtagByStory(int storyId)
        {
            _hashtags.RemoveAll(h => h.Stories.Any(s => s.StoryId == storyId));
            return true;
        }

        public Hashtag GetHashtagById(int hastagId)
        {
            return _hashtags.FirstOrDefault(h => h.HashtagId == hastagId);
        }

        public Hashtag GetHashtagByDesc(string description)
        {
            return GetHashtagList().FirstOrDefault(h => h.Description == description);
        }

        public List<Hashtag> GetHashtagByStory(int storyId)
        {
            return _hashtags.Where(h => h.Stories.Any(s => s.StoryId == storyId)).ToList();
        }

        #endregion

        #region "User"        
        public List<User> GetUserList()
        {
            return _users;
        }
        
        public UserVM AddUser(UserVM user, string role)
        {
            User userTmp = new User();
            userTmp.Nickname = role == Role.admin.ToString() ? user.UserName : user.Nickname;

            userTmp = ConvertVMToUser(user);
            userTmp.IsActive = true;
            userTmp.Id = _users.Max(c => c.Id) + 1;

            _users.Add(userTmp);
            user.Result = ReturnSuccess();
            return user;
        }

        public UserVM UpdateUser(UserVM user, string role)
        {
            User userTmp = _users.FirstOrDefault(u=>u.Id == user.Id);
            userTmp.Email = user.Email;
            userTmp.Phone = user.Phone;
            userTmp.Quote = user.Quote;
            userTmp.Nickname = role == Role.admin.ToString() ? user.UserName : user.Nickname;
            
            user.Result = ReturnSuccess();
            return user;
        }

        public bool ChangePassword(string userName, string currentPassword, string newPassword)
        {
            User user = GetUserByUserName(userName);
            if (user != null && user.PasswordHash == currentPassword)
            {
                user.PasswordHash = newPassword;
                _users.RemoveAll(u => u.Id == user.Id);
                _users.Add(user);
                return true;
            }
            return false;
        }

        public bool DeleteUser(string userId)
        {
            _users.RemoveAll(u => u.Id == userId);
            return true;
        }

        public bool DeactivateUser(string userName)
        {
            User user = GetUserByUserName(userName);
            if (user != null)
            {
                user.IsActive = false;
                _users.RemoveAll(u => u.Id == user.Id);
                _users.Add(user);
            }
            return true;
        }

        public bool ReactivateUser(string userName)
        {
            User user = GetUserByUserName(userName);
            if (user != null)
            {
                user.IsActive = true;
                _users.RemoveAll(u => u.Id == user.Id);
                _users.Add(user);
            }
            return true;
        }

        public List<User> GetUserListByRole(string role)
        {
            return GetUserList().Where(u => u.Roles.Any(r => r.RoleId == role)).ToList();
            //return GetUserList().ToList();
        }

        public User GetUserById(string userId)
        {
            return GetUserList().FirstOrDefault(u => u.Id == userId);
        }

        public UserVM GetUserVMByUserName(string userName)
        {
            return ConvertUserToVM(GetUserByUserName(userName));
        }

        public User GetUserByUserName(string userName)
        {
            return GetUserList().FirstOrDefault(u => u.UserName == userName);
        }

        public User ConvertVMToUser(UserVM input)
        {
            User result = new User()
            {
                Id = input.Id,
                PasswordHash = input.PasswordHash,
                UserName = input.UserName,
                Nickname = input.Nickname,
                Email = input.Email,
                Phone = input.Phone,
                ProfilePic = input.ProfilePic,
                Quote = input.Quote
            };
            return result;
        }

        public UserVM ConvertUserToVM(User input)
        {
            UserVM result = new UserVM()
            {
                Id = input.Id,
                PasswordHash = input.PasswordHash,
                UserName = input.UserName,
                Nickname = input.Nickname,
                Email = input.Email,
                Phone = input.Phone,
                ProfilePic = input.ProfilePic,
                Quote = input.Quote,
                Result = ReturnSuccess()
            };

            return result;
        }

        #endregion
        
    }
}
