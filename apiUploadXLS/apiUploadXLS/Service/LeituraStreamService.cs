namespace apiUploadXLS.Service
{
    public class LeituraStreamService
    {
        private readonly IFormFile _formFile;
        public LeituraStreamService(IFormFile formFile) 
        { 
            _formFile= formFile;
        }

        public Stream LeituraStream()
        {
            using (var stream = new MemoryStream())
            {
                _formFile.CopyTo(stream);

                var byteArray = stream.ToArray();

                return new MemoryStream(byteArray);
            }
        }
    }
}
