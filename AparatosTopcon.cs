using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConexionTopCon
{
    public class AparatosTopcon
    {
        public AparatosTopcon()
        {
            patient = new Patient();
            common = new Common();
            Operator = new Operator();
        }

        public Patient patient { get; set; }
        public Common common { get; set; }
        public Operator Operator { get; set; }  
    }

    [XmlRoot(ElementName = "Patient")]
    public class Patient
    {

        [XmlElement(ElementName = "No.")]
        public int? No { get; set; }

        [XmlElement(ElementName = "ID")]
        public int? ID { get; set; }

        [XmlElement(ElementName = "FirstName")]
        public string? FirstName { get; set; }

        [XmlElement(ElementName = "MiddleName")]
        public string? MiddleName { get; set; }

        [XmlElement(ElementName = "LastName")]
        public string? LastName { get; set; }

        [XmlElement(ElementName = "Sex")]
        public string? Sex { get; set; }

        [XmlElement(ElementName = "Age")]
        public int? Age { get; set; }

        [XmlElement(ElementName = "DOB")]
        public string? DOB { get; set; }

        [XmlElement(ElementName = "NameJ1")]
        public string? NameJ1 { get; set; }

        [XmlElement(ElementName = "NameJ2")]
        public string? NameJ2 { get; set; }
    }


    [XmlRoot(ElementName = "Operator")]
    public class Operator
    {

        [XmlElement(ElementName = "No.")]
        public object No { get; set; }

        [XmlElement(ElementName = "ID")]
        public object ID { get; set; }
    }

    [XmlRoot(ElementName = "Common")]
    public class Common
    {

        [XmlElement(ElementName = "Company")]
        public string? Company { get; set; }

        [XmlElement(ElementName = "ModelName")]
        public string? ModelName { get; set; }

        [XmlElement(ElementName = "MachineNo")]
        public int? MachineNo { get; set; }

        [XmlElement(ElementName = "ROMVersion")]
        public string? ROMVersion { get; set; }

        [XmlElement(ElementName = "Version")]
        public string? Version { get; set; }

        [XmlElement(ElementName = "Date")]
        public DateTime? Date { get; set; }

        [XmlElement(ElementName = "Time")]
        public DateTime? Time { get; set; }

        [XmlElement(ElementName = "Patient")]
        public Patient? Patient { get; set; }

        [XmlElement(ElementName = "Duration")]
        public DateTime? Duration { get; set; }

        [XmlElement(ElementName = "DateFormat")]
        public string? DateFormat { get; set; }

        [XmlElement(ElementName = "Operator")]
        public Operator? Operator { get; set; }
    }
}
