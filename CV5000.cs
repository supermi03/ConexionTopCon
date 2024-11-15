using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConexionTopCon
{
    public class CV5000 : AparatosTopcon
    {
        public CV5000() {

            r = new R();
            l = new L();
            refractionData = new RefractionData();
            pd = new PD();
            measure = new Measure();
        }
        public R r { get; set; }
        public L l { get; set; }
        public RefractionData refractionData { get; set; }
        public PD pd { get; set; }
        public Type type { get; set; }
        public Measure measure { get; set; }


        [XmlRoot(ElementName = "R")]
        public class R
        {

            [XmlElement(ElementName = "Sph")]
            public string? Sph { get; set; }

            [XmlElement(ElementName = "Cyl")]
            public string? Cyl { get; set; }

            [XmlElement(ElementName = "Axis")]
            public string? Axis { get; set; }

            [XmlElement(ElementName = "HPri")]
            public string? HPri { get; set; }

            [XmlElement(ElementName = "HBase")]
            public string? HBase { get; set; }

            [XmlElement(ElementName = "VPri")]
            public string? VPri { get; set; }

            [XmlElement(ElementName = "VBase")]
            public string? VBase { get; set; }

            [XmlElement(ElementName = "Prism")]
            public string? Prism { get; set; }

            [XmlElement(ElementName = "Angle")]
            public string? Angle { get; set; }

            [XmlAttribute(AttributeName = "unit")]
            public string? Unit { get; set; }
        }

        [XmlRoot(ElementName = "L")]
        public class L
        {

            [XmlElement(ElementName = "Sph")]
            public string? Sph { get; set; }

            [XmlElement(ElementName = "Cyl")]
            public string? Cyl { get; set; }

            [XmlElement(ElementName = "Axis")]
            public string? Axis { get; set; }

            [XmlElement(ElementName = "HPri")]
            public string? HPri { get; set; }

            [XmlElement(ElementName = "HBase")]
            public string? HBase { get; set; }

            [XmlElement(ElementName = "VPri")]
            public string? VPri { get; set; }

            [XmlElement(ElementName = "VBase")]
            public string? VBase { get; set; }

            [XmlElement(ElementName = "Prism")]
            public string? Prism { get; set; }

            [XmlElement(ElementName = "Angle")]
            public string? Angle { get; set; }

            [XmlAttribute(AttributeName = "unit")]
            public string? Unit { get; set; }
        }

        [XmlRoot(ElementName = "RefractionData")]
        public class RefractionData
        {

            [XmlElement(ElementName = "R")]
            public R? R { get; set; }

            [XmlElement(ElementName = "L")]
            public L? L { get; set; }
        }

        [XmlRoot(ElementName = "PD")]
        public class PD
        {

            [XmlElement(ElementName = "R")]
            public string? R { get; set; }

            [XmlElement(ElementName = "L")]
            public string? L { get; set; }

            [XmlElement(ElementName = "B")]
            public string B { get; set; }
        }


        [XmlRoot(ElementName = "Measure")]
        public class Measure
        {

            [XmlElement(ElementName = "RefractionTest")]
            public string? RefractionTest { get; set; }

            [XmlAttribute(AttributeName = "Type")]
            public string? Type { get; set; }

            [XmlAttribute(AttributeName = "TypeName")]
            public string? TypeName { get; set; }

            [XmlAttribute(AttributeName = "ExamDistance")]
            public string? ExamDistance { get; set; }

            [XmlAttribute(AttributeName = "Distance")]
            public string? Distance { get; set; }

        }

    }
}
