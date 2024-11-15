using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConexionTopCon
{
    public class TRK2P : AparatosTopcon
    {
        public TRK2P() {
            list = new List();
            median = new Median();
            r = new R();
            l = new L();
            refe = new REF();
            pd = new PD();
            measure = new Measure();
            r1 = new R1();
            r2 = new R2();
            average = new Average();
            km = new KM();
            confidence = new Confidence();
            iopmmhg = new IOPMmHg();
            ioppa = new IOPPa();
            tm = new TM();
            param1 = new Param1();
            cct = new CCT();
            measured = new Measured();
            corrected = new Corrected();
            cctmm = new CCTMm();
        }
        public Cylinder cylinder { get; set; }
        public List list { get; set; }
        public Median median { get; set; }
        public R r { get; set; }
        public L l { get; set; }
        public REF refe { get; set; }
        public PD pd { get; set; }
        public Measure measure { get; set; }
        public R1 r1 { get; set; }
        public R2 r2 { get; set; }
        public Average average { get; set; }
        public KM km { get; set; }
        public Confidence confidence { get; set; }
        public IOPMmHg iopmmhg { get; set; }
        public IOPPa ioppa { get; set; }
        public TM tm { get; set; }
        public Param1 param1 { get; set; }
        public CCT cct { get; set; }
        public Measured measured { get; set; }
        public Corrected corrected { get; set; }
        public Formula1 formula1 { get; set; }
        public CorrectedIOP correctedIOP { get; set; }
        public CCTMm cctmm { get; set; }





        [XmlRoot(ElementName = "Cylinder")]
        public class Cylinder
        {

            [XmlAttribute(AttributeName = "unit")]
            public string? Unit { get; set; }

            [XmlText]
            public string? Text { get; set; }

            [XmlElement(ElementName = "Power")]
            public string? Power { get; set; }

            [XmlElement(ElementName = "Axis")]
            public string? Axis { get; set; }
        }



        [XmlRoot(ElementName = "List")]
        public class List
        {

            [XmlElement(ElementName = "Sphere")]
            public string? Sphere { get; set; }

            [XmlElement(ElementName = "Cylinder")]
            public string? Cylinder { get; set; }

            [XmlElement(ElementName = "Axis")]
            public string? Axis { get; set; }

            [XmlElement(ElementName = "SE")]
            public string? SE { get; set; }

            [XmlElement(ElementName = "CataractMode")]
            public string? CataractMode { get; set; }

            [XmlElement(ElementName = "IOLMode")]
            public string? IOLMode { get; set; }

            [XmlElement(ElementName = "ConfidenceIndex")]
            public string? ConfidenceIndex { get; set; }

            [XmlAttribute(AttributeName = "No")]
            public int? No { get; set; }

            [XmlText]
            public string? Text { get; set; }

            [XmlElement(ElementName = "R1")]
            public string? R1 { get; set; }

            [XmlElement(ElementName = "R2")]
            public string? R2 { get; set; }

            [XmlElement(ElementName = "Average")]
            public string? Average { get; set; }

            [XmlElement(ElementName = "IOP_mmHg")]
            public string? IOPMmHg { get; set; }

            [XmlElement(ElementName = "IOP_Pa")]
            public string? IOPPa { get; set; }

            [XmlElement(ElementName = "Alignment_Mode")]
            public string? AlignmentMode { get; set; }


            [XmlElement(ElementName = "Pressure_Range")]
            public string? PressureRange { get; set; }

            [XmlElement(ElementName = "CCT_mm")]
            public string? CCTMm { get; set; }
        }

        [XmlRoot(ElementName = "Median")]
        public class Median
        {

            [XmlElement(ElementName = "Sphere")]
            public string? Sphere { get; set; }

            [XmlElement(ElementName = "Cylinder")]
            public string? Cylinder { get; set; }

            [XmlElement(ElementName = "Axis")]
            public string? Axis { get; set; }

            [XmlElement(ElementName = "SE")]
            public string? SE { get; set; }

            [XmlElement(ElementName = "R1")]
            public string? R1 { get; set; }

            [XmlElement(ElementName = "R2")]
            public string? R2 { get; set; }

            [XmlElement(ElementName = "Average")]
            public string? Average { get; set; }

            [XmlElement(ElementName = "ConfidenceIndex")]
            public string? ConfidenceIndex { get; set; }
        }

        [XmlRoot(ElementName = "R")]
        public class R
        {

            [XmlElement(ElementName = "List")]
            public List<List>? List { get; set; }

            [XmlElement(ElementName = "Median")]
            public string? Median { get; set; }

            [XmlElement(ElementName = "Average")]
            public string? Average { get; set; }

            [XmlElement(ElementName = "Param1")]
            public string? Param1 { get; set; }

            [XmlElement(ElementName = "Param2")]
            public string? Param2 { get; set; }

            [XmlElement(ElementName = "CCT")]
            public string? CCT { get; set; }

            [XmlElement(ElementName = "Measured")]
            public string? Measured { get; set; }

            [XmlElement(ElementName = "Corrected")]
            public string? Corrected { get; set; }
        }

        [XmlRoot(ElementName = "L")]
        public class L
        {

            [XmlElement(ElementName = "List")]
            public List<List>? List { get; set; }

            [XmlElement(ElementName = "Median")]
            public string? Median { get; set; }

            [XmlElement(ElementName = "Average")]
            public string? Average { get; set; }

            [XmlElement(ElementName = "Param1")]
            public string? Param1 { get; set; }

            [XmlElement(ElementName = "Param2")]
            public string? Param2 { get; set; }

            [XmlElement(ElementName = "CCT")]
            public string? CCT { get; set; }

            [XmlElement(ElementName = "Measured")]
            public string? Measured { get; set; }

            [XmlElement(ElementName = "Corrected")]
            public string? Corrected { get; set; }
        }

        [XmlRoot(ElementName = "REF")]
        public class REF
        {

            [XmlElement(ElementName = "R")]
            public R? R { get; set; }

            [XmlElement(ElementName = "L")]
            public L? L { get; set; }
        }


        [XmlRoot(ElementName = "PD")]
        public class PD
        {

            [XmlElement(ElementName = "WorkingDistance")]
            public string? WorkingDistance { get; set; }

            [XmlElement(ElementName = "Distance")]
            public string? Distance { get; set; }

            [XmlElement(ElementName = "Near")]
            public string? Near { get; set; }
        }

        [XmlRoot(ElementName = "Measure")]
        public class Measure
        {

            [XmlElement(ElementName = "VD")]
            public string? VD { get; set; }

            [XmlElement(ElementName = "DiopterStep")]
            public string? DiopterStep { get; set; }

            [XmlElement(ElementName = "AxisStep")]
            public string? AxisStep { get; set; }

            [XmlElement(ElementName = "CylinderMode")]
            public string? CylinderMode { get; set; }

            [XmlElement(ElementName = "REF")]
            public string? REF { get; set; }

            [XmlElement(ElementName = "PD")]
            public string? PD { get; set; }

            [XmlAttribute(AttributeName = "type")]
            public string? Type { get; set; }

            [XmlText]
            public string? Text { get; set; }

            [XmlElement(ElementName = "RefractiveIndex")]
            public string? RefractiveIndex { get; set; }

            [XmlElement(ElementName = "KM")]
            public string? KM { get; set; }

            [XmlElement(ElementName = "Confidence")]
            public string? Confidence { get; set; }

            [XmlElement(ElementName = "TM")]
            public List<TM>? TM { get; set; }

            [XmlElement(ElementName = "CorrectedIOP")]
            public List<CorrectedIOP>? CorrectedIOP { get; set; }

            [XmlElement(ElementName = "CCT")]
            public string? CCT { get; set; }
        }


        [XmlRoot(ElementName = "R1")]
        public class R1
        {

            [XmlElement(ElementName = "Radius")]
            public string? Radius { get; set; }

            [XmlElement(ElementName = "Power")]
            public string? Power { get; set; }

            [XmlElement(ElementName = "Axis")]
            public string? Axis { get; set; }
        }

        [XmlRoot(ElementName = "R2")]
        public class R2
        {

            [XmlElement(ElementName = "Radius")]
            public string? Radius { get; set; }

            [XmlElement(ElementName = "Power")]
            public string? Power { get; set; }

            [XmlElement(ElementName = "Axis")]
            public string? Axis { get; set; }
        }

        [XmlRoot(ElementName = "Average")]
        public class Average
        {

            [XmlElement(ElementName = "Radius")]
            public string? Radius { get; set; }

            [XmlElement(ElementName = "Power")]
            public string? Power { get; set; }

            [XmlElement(ElementName = "IOP_mmHg")]
            public string? IOPMmHg { get; set; }

            [XmlElement(ElementName = "IOP_Pa")]
            public string? IOPPa { get; set; }
        }

        [XmlRoot(ElementName = "KM")]
        public class KM
        {

            [XmlElement(ElementName = "R")]
            public R? R { get; set; }

            [XmlElement(ElementName = "L")]
            public L? L { get; set; }
        }

        [XmlRoot(ElementName = "Confidence")]
        public class Confidence
        {

            [XmlElement(ElementName = "R")]
            public R? R { get; set; }

            [XmlElement(ElementName = "L")]
            public L? L { get; set; }
        }

        [XmlRoot(ElementName = "IOP_mmHg")]
        public class IOPMmHg
        {

            [XmlAttribute(AttributeName = "unit")]
            public string? Unit { get; set; }

            [XmlText]
            public double? Text { get; set; }
        }

        [XmlRoot(ElementName = "IOP_Pa")]
        public class IOPPa
        {

            [XmlAttribute(AttributeName = "unit")]
            public string? Unit { get; set; }
        }

        [XmlRoot(ElementName = "TM")]
        public class TM
        {

            [XmlElement(ElementName = "R")]
            public R? R { get; set; }

            [XmlElement(ElementName = "L")]
            public L? L { get; set; }

            [XmlElement(ElementName = "RL_Order")]
            public string? RLOrder { get; set; }
        }

        [XmlRoot(ElementName = "Param1")]
        public class Param1
        {

            [XmlAttribute(AttributeName = "unit")]
            public string? Unit { get; set; }

            [XmlText]
            public string? Text { get; set; }
        }

        [XmlRoot(ElementName = "CCT")]
        public class CCT
        {

            [XmlAttribute(AttributeName = "unit")]
            public string? Unit { get; set; }

            [XmlText]
            public string? Text { get; set; }

            [XmlElement(ElementName = "RL_Order")]
            public string? RLOrder { get; set; }

            [XmlElement(ElementName = "R")]
            public R? R { get; set; }

            [XmlElement(ElementName = "L")]
            public L? L { get; set; }
        }

        [XmlRoot(ElementName = "Measured")]
        public class Measured
        {

            [XmlElement(ElementName = "IOP_mmHg")]
            public string? IOPMmHg { get; set; }

            [XmlElement(ElementName = "IOP_Pa")]
            public string? IOPPa { get; set; }
        }

        [XmlRoot(ElementName = "Corrected")]
        public class Corrected
        {

            [XmlElement(ElementName = "IOP_mmHg")]
            public IOPMmHg? IOPMmHg { get; set; }

            [XmlElement(ElementName = "IOP_Pa")]
            public IOPPa? IOPPa { get; set; }
        }

        [XmlRoot(ElementName = "Formula1")]
        public class Formula1
        {

            [XmlElement(ElementName = "R")]
            public R? R { get; set; }

            [XmlElement(ElementName = "L")]
            public L? L { get; set; }

            [XmlAttribute(AttributeName = "No")]
            public int? No { get; set; }

            [XmlText]
            public string? Text { get; set; }
        }

        [XmlRoot(ElementName = "CorrectedIOP")]
        public class CorrectedIOP
        {

            [XmlElement(ElementName = "Formula1")]
            public Formula1? Formula1 { get; set; }

            [XmlElement(ElementName = "R")]
            public R? R { get; set; }

            [XmlElement(ElementName = "L")]
            public L? L { get; set; }
        }

        [XmlRoot(ElementName = "CCT_mm")]
        public class CCTMm
        {

            [XmlAttribute(AttributeName = "unit")]
            public string? Unit { get; set; }

            [XmlText]
            public double? Text { get; set; }
        }
    }
}
