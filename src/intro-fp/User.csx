public class User
{
    public string Name { get; }
    public int Age { get; }

    public User(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public static User CelebrateBirthDay(User user)
    {
        return new User(user.Name, user.Age);
    }
}

public class UserTests
{
    public void SomeTest()
    {
        var user = new User("Joey", 24);
        var olderJoe = User.CelebrateBirthDay(user);
    }
}