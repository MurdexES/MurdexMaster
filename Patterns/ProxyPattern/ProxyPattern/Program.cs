using System.Xml.Linq;

Console.WriteLine("");

IContainer container = new ProxyContainer("CarContainer");

//Creating container
container.Show();

//Taking container
container.Show();


public interface IContainer
{
    void Show();
}

public class OriginalContainer : IContainer
{
    private string _containerName;

    public OriginalContainer(string containerName)
    {
        _containerName = containerName;
        TakeFromStorehouse(containerName);
    }

    public void Show()
    {
        Console.WriteLine("Showing container " + _containerName);
    }

    private void TakeFromStorehouse(string containerName)
    {
        Console.WriteLine("Loading container from " + containerName + " from Storehouse");
    }
}

public class ProxyContainer : IContainer
{
    private OriginalContainer _originalContainer;
    private string _containerName;

    public ProxyContainer(string containerName)
    {
        _containerName = containerName;
    }

    public void Show()
    {
        if (_originalContainer == null)
        {
            _originalContainer = new OriginalContainer(_containerName);
        }
        _originalContainer.Show();
    }
}
