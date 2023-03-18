using System;

namespace UserLogin;

public class Log
{
    private Int32 logId;
    private String content;
    private DateTime created;

    public Log()
    {
    }

    public Log(string content, DateTime created)
    {
        this.content = content;
        this.created = created;
    }

    public int LogId
    {
        get => logId;
        set => logId = value;
    }

    public string Content
    {
        get => content;
        set => content = value ?? throw new ArgumentNullException(nameof(value));
    }

    public DateTime Created
    {
        get => created;
        set => created = value;
    }
}