namespace educae.biblioteca.domain.ValueObject;

public class Url
{
    public string link { get; private set; }
    
    protected Url() { }

    public Url(string link)
    {
        setLink(link);
    }

    private void setLink(string urlLink)
    {
        if (!string.IsNullOrEmpty(urlLink))
        {
            if (urlLink.Contains("http"))
                this.link = urlLink;
            else
                this.link = "http://" + urlLink;
        }
    }
}