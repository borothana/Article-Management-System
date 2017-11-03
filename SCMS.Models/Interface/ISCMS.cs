using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCMS.Models.ViewModels;

namespace SCMS.Models.Interface
{
    public interface ISCMS
    {
        #region "Category"
        Category GetCategoryById(int categoryId);
        List<Category> GetCategoryList();
        int AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int categoryId);
        #endregion

        #region "Intimacy"
        Intimacy GetIntimacyById(int itimacyId);
        List<Intimacy> GetIntimacyList();
        int AddIntimacy(Intimacy intimacy);
        bool UpdateIntimacy(Intimacy intimacy);
        bool DeleteIntimacy(int intimacyId);
        #endregion
        
        #region "Hashtag"
        Hashtag GetHashtagById(int hastagId);
        List<Hashtag> GetHashtagByStory(int storyId);
        List<Hashtag> GetHashtagList();
        int AddHastag(Hashtag hashtag);
        bool UpdateHashtag(Hashtag hashtag);
        bool DeleteHashtagById(int hashtagId);
        bool DeleteHashtagByStory(int storyId);
        #endregion

        #region "Comment"
        Comment GetCommentById(int commentId);
        List<Comment> GetCommentByStory(int storyId);
        List<Comment> GetCommentList();
        int AddComment(Comment comment);
        bool UpdateComment(Comment comment);
        bool DeleteCommentById(int commentId);
        bool DeleteCommentByStory(int storyId);
        #endregion

        #region "Story"
        Story GetStoryById(int StoryId);
        List<Story> GetStoryList();
        int AddStory(StoryVM storyVM);
        bool UpdateStory(StoryVM storyVM);
        bool DeleteStory(int StoryId);
        #endregion

        #region "User"
        List<User> GetUserList();
        User GetUserById(string userId);
        User GetUserByUserName(string userName);
        List<User> GetUserListByRole(string role);
        string AddUser(User user, string role);
        Task<bool> DeactivateUser(string userId);
        Task<bool> ReactivateUser(string userId);
        bool ChangePassword(string userId, string currentPassword, string newPassword);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(string userId);
        Task<bool> Login(string userId, string password);
        #endregion

    }
}
