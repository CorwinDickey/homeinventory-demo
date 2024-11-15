namespace Domain.MetaData
{
    /// <summary>
    /// Stores the metadata for a fileblob
    /// </summary>
    public class FileBlob : AuditableEntity
    {
        /// <summary>
        /// Gets or sets the stringified Guid
        /// </summary>
        public string BlobId { get; set; }

        /// <summary>
        /// Gets or sets the human readable file name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the file's Mime type
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Gets or sets the file's length in bytes
        /// </summary>
        public long Size { get; set; }
    }
}
