
namespace Common.Models.Users
{
  public  class UserOutput
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        //Name + Family
        public string DisplayName { get; set; }
    }
}
