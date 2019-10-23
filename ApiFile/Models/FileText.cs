using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.AspNetCore.Http;

namespace ApiFile.Models
{
    //Store data of log trace
    public class FileText
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long IdDocument { get; set; }
        public DateTime Date { get; set; }
        [NotMappedAttribute]
        public IFormFile File { get; set; }
    }
}