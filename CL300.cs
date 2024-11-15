using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static ConexionTopCon.CV5000;
using static ConexionTopCon.TRK2P;

namespace ConexionTopCon
{
    public class CL300:AparatosTopcon
    {
        public CL300()
        {
            r = new R();
            l = new L();
            lm = new LM();
            measure = new Measure();
        }
        public R r { get; set; }
        public L l { get; set; }
        public LM lm { get; set; }
        public Measure measure { get; set; }
    }

    [XmlRoot(ElementName = "R")]
    public class R
    {

        [XmlElement(ElementName = "Sphere")]
        public string? Sphere { get; set; }

        [XmlElement(ElementName = "Cylinder")]
        public string? Cylinder { get; set; }

        [XmlElement(ElementName = "Axis")]
        public string? Axis { get; set; }

        [XmlElement(ElementName = "Add1")]
        public string? Add1 { get; set; }

        [XmlElement(ElementName = "Add2")]
        public string? Add2 { get; set; }

        [XmlElement(ElementName = "H")]
        public string? H { get; set; }

        [XmlElement(ElementName = "V")]
        public string? V { get; set; }
    }

    [XmlRoot(ElementName = "L")]
    public class L
    {

        [XmlElement(ElementName = "Sphere")]
        public string? Sphere { get; set; }

        [XmlElement(ElementName = "Cylinder")]
        public string? Cylinder { get; set; }

        [XmlElement(ElementName = "Axis")]
        public string? Axis { get; set; }

        [XmlElement(ElementName = "Add1")]
        public string? Add1 { get; set; }

        [XmlElement(ElementName = "Add2")]
        public string? Add2 { get; set; }

        [XmlElement(ElementName = "H")]
        public string? H { get; set; }

        [XmlElement(ElementName = "V")]
        public string? V { get; set; }
    }

    [XmlRoot(ElementName = "LM")]
    public class LM
    {

        [XmlElement(ElementName = "R")]
        public R? R { get; set; }

        [XmlElement(ElementName = "L")]
        public L? L { get; set; }
    }

    [XmlRoot(ElementName = "Measure")]
    public class Measure
    {

        [XmlElement(ElementName = "DiopterStep")]
        public string? DiopterStep { get; set; }

        [XmlElement(ElementName = "AxisStep")]
        public string? AxisStep { get; set; }

        [XmlElement(ElementName = "PrismStep")]
        public string? PrismStep { get; set; }

        [XmlElement(ElementName = "CylinderMode")]
        public string? CylinderMode { get; set; }

        [XmlElement(ElementName = "LensType")]
        public string? LensType { get; set; }

        [XmlElement(ElementName = "AbbeNumber")]
        public string? AbbeNumber { get; set; }

        [XmlElement(ElementName = "Wavelength")]
        public string? Wavelength { get; set; }

        [XmlElement(ElementName = "LM")]
        public string? LM { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string? Type { get; set; }

        [XmlText]
        public string? Text { get; set; }
    }


}
