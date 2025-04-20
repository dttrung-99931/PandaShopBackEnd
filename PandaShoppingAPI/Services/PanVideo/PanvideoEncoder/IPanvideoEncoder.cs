namespace PandaShoppingAPI.Services 
{
    public interface IPanvideoEncoder
    {   
        bool Encode(string inputVideoPath, string outputVideoDir, string outputVideoName);
    }
}