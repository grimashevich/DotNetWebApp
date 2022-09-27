namespace EmployeeService;

public static class GuidConverter
{
    public static Guid ToGuid(int value)
    {
        byte[] bytes = new byte[16];
        BitConverter.GetBytes(value).CopyTo(bytes, 0);
        return new Guid(bytes);
    }

    public static int FromGuid(Guid value)
    {
        return (int.Parse(value.ToString()));
    }
}