using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Windows.Controls;
using static ConexionTopCon.CV5000;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml;

namespace ConexionTopCon
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Ruta de la carpeta donde se encuentran los archivos XML
            string directoryPath = @"C:\Users\migue\source\repos\ConexionTopCon\xml\";

            try
            {
                // Obtener todos los archivos XML en la carpeta
                var xmlFiles = Directory.GetFiles(directoryPath, "*.xml");

                if (xmlFiles.Length == 0)
                {
                    MessageBox.Show("No se encontraron archivos XML en la carpeta.");
                    return;
                }

                // Crear las instancias de los objetos
                CL300 obj_cl300 = new();
                CV5000 obj_cv5000 = new();
                TRK2P obj_trk2p = new();

                foreach (var xmlFilePath in xmlFiles)
                {
                    // Cargar el archivo XML
                    XDocument xdoc = XDocument.Load(xmlFilePath);

                    // Extraer el ModelName desde el XML
                    string modelName = ExtractModelName(xdoc.Root);

                    // Llamar al método correspondiente según el modelo
                    ExtractMethod(modelName, xdoc.Root, obj_cl300, obj_cv5000, obj_trk2p);
                }

                // Mostrar los resultados si es necesario
                MessageBox.Show("Datos extraídos exitosamente.");
            }
            catch (Exception ex)
            {
                // Manejo de errores si ocurre algún problema con los archivos XML
                MessageBox.Show("Error al leer los archivos XML: " + ex.Message);
            }
        }

        private string? ExtractModelName(XElement element)
        {
            // Definir el espacio de nombres para nsCommon
            XNamespace nsCommon = "http://www.joia.or.jp/standardized/namespaces/Common";

            // Intentar extraer el valor de "ModelName" usando el espacio de nombres adecuado
            var modelNameElement = element.Descendants(nsCommon + "ModelName").FirstOrDefault();
            return modelNameElement?.Value?.Trim();
        }

        // Método para decidir cuál Extract se llama según el modelo
        private void ExtractMethod(string modelName, XElement element, CL300 obj_cl300, CV5000 obj_cv5000, TRK2P obj_trk2p)
        {
            // Llamar al método correspondiente según el nombre del modelo
            if (modelName == "CL-300")
            {

                ExtractCommons(element, obj_cl300);
                ExtractDataCl300(element, obj_cl300);
                ShowMessageCL300(obj_cl300);
            }
            else if (modelName == "CV-5000")
            {

                ExtractCommons(element, obj_cv5000);
                ExtractCV5000Data(element, obj_cv5000);
                ShowCV5000Message(obj_cv5000);

            }
            else if (modelName == "TRK-2P")
            {

                ExtractCommons(element, obj_trk2p);
                ExtractDataTRK2P(element, obj_trk2p);
                ShowMessageTRK2P(obj_trk2p);
            }
            else
            {
                MessageBox.Show("Modelo no reconocido.");
            }
        }
        private void ExtractDataCl300(XElement element, CL300 obj_cl300)
        {

            if (element.Name.LocalName == "Ophthalmology")
            {
                foreach (var childElement in element.Elements())
                {
                    if (childElement.Name.LocalName == "Measure")
                    {
                        foreach (var commonChild in childElement.Elements())
                        {
                            switch (commonChild.Name.LocalName)
                            {
                                case "DiopterStep":
                                    obj_cl300.measure.DiopterStep = commonChild.Value?.Trim();
                                    break;

                                case "AxisStep":
                                    obj_cl300.measure.AxisStep = commonChild.Value?.Trim();
                                    break;
                                case "PrismStep":
                                        obj_cl300.measure.PrismStep = commonChild.Value?.Trim();
                                    break;
                                case "CylinderMode":
                                    obj_cl300.measure.CylinderMode = commonChild.Value?.Trim();
                                    break;
                                case "LensType":
                                    obj_cl300.measure.LensType = commonChild.Value?.Trim();
                                    break;
                                case "AbbeNumber":
                                        obj_cl300.measure.AbbeNumber = commonChild.Value?.Trim();
                                    break;
                                case "Wavelength":
                                        obj_cl300.measure.Wavelength = commonChild.Value?.Trim();
                                    break;

                                case "LM":
                                    foreach (var patientChild in commonChild.Elements())
                                    {
                                        switch (patientChild.Name.LocalName)
                                        {
                                            case "R":
                                                foreach (var childChild in patientChild.Elements())
                                                {
                                                    switch (childChild.Name.LocalName)
                                                    {
                                                        case "Sphere":
                                                                obj_cl300.r.Sphere = childChild.Value?.Trim();
                                                            break;
                                                        case "Cylinder":
                                                            obj_cl300.r.Cylinder = childChild.Value?.Trim();
                                                            break;
                                                        case "Axis":
                                                            obj_cl300.r.Axis = childChild.Value?.Trim();
                                                            break;
                                                        case "Add1":
                                                            obj_cl300.r.Add1 = childChild.Value?.Trim();
                                                            break;
                                                        case "Add2":
                                                            obj_cl300.r.Add2 = childChild.Value?.Trim();
                                                            break;
                                                        case "H":
                                                                obj_cl300.r.H = childChild.Value?.Trim();
                                                            break;
                                                        case "V":
                                                                obj_cl300.r.V = childChild.Value?.Trim();
                                                            break;
                                                    }
                                                }
                                            break;
                                            case "L":
                                                foreach (var childChild in patientChild.Elements())
                                                {
                                                    switch (childChild.Name.LocalName)
                                                    {
                                                        case "Sphere":
                                                                obj_cl300.l.Sphere = childChild.Value?.Trim();
                                                            break;
                                                        case "Cylinder":
                                                            obj_cl300.l.Cylinder = childChild.Value?.Trim();
                                                            break;
                                                        case "Axis":
                                                            obj_cl300.l.Axis = childChild.Value?.Trim();
                                                            break;
                                                        case "Add1":
                                                            obj_cl300.l.Add1 = childChild.Value?.Trim();
                                                            break;
                                                        case "Add2":
                                                            obj_cl300.l.Add2 = childChild.Value?.Trim();
                                                            break;
                                                        case "H":
                                                                obj_cl300.l.H = childChild.Value?.Trim();
                                                            break;
                                                        case "V":
                                                                obj_cl300.l.V = childChild.Value?.Trim();
                                                            break;
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }
        private void ShowMessageCL300(CL300 obj_cl300)
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine("Ophthalmology Data:");
            message.AppendLine($"Common:");
            message.AppendLine($"- Company: {obj_cl300?.common?.Company}");
            message.AppendLine($"- ModelName: {obj_cl300?.common?.ModelName}");
            message.AppendLine($"- MachineNo: {obj_cl300?.common?.MachineNo}");
            message.AppendLine($"- ROMVersion: {obj_cl300?.common?.ROMVersion}");
            message.AppendLine($"- Version: {obj_cl300?.common?.Version}");
            message.AppendLine($"- Date: {obj_cl300?.common?.Date?.ToString("yyyy-MM-dd")}");
            message.AppendLine($"- Time: {obj_cl300?.common?.Time?.ToString("HH:mm:ss")}");

            message.AppendLine("Patient Data:");
            message.AppendLine($"- FirstName: {obj_cl300?.patient?.FirstName}"); 
            message.AppendLine($"- MiddleName: {obj_cl300?.patient?.MiddleName}");
            message.AppendLine($"- LastName: {obj_cl300?.patient?.LastName}");
            message.AppendLine($"- Sex: {obj_cl300?.patient?.Sex}");
            message.AppendLine($"- Age: {obj_cl300?.patient?.Age}");

            message.AppendLine("Measure Data:");
            message.AppendLine($"- DiopterStep Unit: {obj_cl300?.measure.DiopterStep}");
            message.AppendLine($"- AxisStep Unit: {obj_cl300?.measure?.AxisStep ?? "N/A"}");
            message.AppendLine($"- PrismStep Unit: {obj_cl300?.measure?.PrismStep ?? "N/A"}");
            message.AppendLine($"- CylinderMode: {obj_cl300?.measure.CylinderMode ?? "N/A"}");
            message.AppendLine($"- LensType: {obj_cl300?.measure?.LensType ?? "N/A"}");
            message.AppendLine($"- AbbeNumber: {obj_cl300?.measure?.AbbeNumber ?? "N/A"}");
            message.AppendLine($"- Wavelength: {obj_cl300?.measure?.Wavelength ?? "N/A"}");
            message.AppendLine($"- Measure Type: {obj_cl300?.measure?.Type ?? "N/A"}");

            message.AppendLine("Right Eye (R) Data:");
            message.AppendLine($"- Sphere: {obj_cl300?.r?.Sphere ?? "N/A"}");
            message.AppendLine($"- Cylinder: {obj_cl300?.r?.Cylinder ?? "N/A"}");
            message.AppendLine($"- Axis: {obj_cl300?.r?.Axis ?? "N/A"}");
            message.AppendLine($"- Add1: {obj_cl300?.r?.Add1 ?? "N/A"}");
            message.AppendLine($"- Add2: {obj_cl300?.r?.Add2 ?? "N/A"}");
            message.AppendLine($"- H Prism: {obj_cl300?.r?.H ?? "N/A"}");
            message.AppendLine($"- V Prism: {obj_cl300?.r?.V ?? "N/A"}");

            message.AppendLine("Left Eye (L) Data:");
            message.AppendLine($"- Sphere: {obj_cl300?.l?.Sphere ?? "N/A"}");
            message.AppendLine($"- Cylinder: {obj_cl300?.l?.Cylinder ?? "N/A"}");
            message.AppendLine($"- Axis: {obj_cl300?.l?.Axis ?? "N/A"}");
            message.AppendLine($"- Add1: {obj_cl300?.l?.Add1 ?? "N/A"}");
            message.AppendLine($"- Add2: {obj_cl300?.l?.Add2 ?? "N/A"}");
            message.AppendLine($"- H Prism: {obj_cl300?.l?.H ?? "N/A"}");
            message.AppendLine($"- V Prism: {obj_cl300?.l?.V ?? "N/A"}");

            message.AppendLine("LM Data:");
            message.AppendLine($"- Right Eye (R): {obj_cl300.lm.R }");
            message.AppendLine($"- Left Eye (L): {obj_cl300.lm.L  }");

            // Mostrar el mensaje en un cuadro de mensaje (MessageBox) o en la consola
            MessageBox.Show(message.ToString(), "Datos del CL300");
            //Console.WriteLine(message.ToString()); // Usar en caso de aplicaciones de consola
        }

        private void ExtractCV5000Data(XElement element, CV5000 obj_cv5000)
        {
            if (element.Name.LocalName == "Ophthalmology")
            {
                foreach (var childElement in element.Elements())
                {
                    if (childElement.Name.LocalName == "Measure")
                    {
                        foreach (var commonChild in childElement.Elements())
                        {
                            switch (commonChild.Name.LocalName)
                            {
                                case "RefractionTest":
                                    foreach (var refactChild in commonChild.Elements())
                                    {
                                        switch (refactChild.Name.LocalName)
                                        {
                                            case "Type":
                                                foreach (var rerefactChild in refactChild.Elements())
                                                {
                                                    switch (rerefactChild.Name.LocalName)
                                                    {
                                                        case "TypeName":
                                                            obj_cv5000.measure.TypeName = rerefactChild.Value?.Trim();
                                                            break;
                                                        case "ExamDistance":
                                                            foreach (var rererefactChild in rerefactChild.Elements())
                                                            {
                                                                switch (rererefactChild.Name.LocalName)
                                                                {
                                                                    case "Distance":
                                                                        obj_cv5000.measure.Distance = rererefactChild.Value?.Trim();
                                                                        break;
                                                                    case "RefractionData":
                                                                        foreach (var patientChild in rererefactChild.Elements())
                                                                        {
                                                                            switch (patientChild.Name.LocalName)
                                                                            {
                                                                                case "R":
                                                                                    foreach (var childChild in patientChild.Elements())
                                                                                    {
                                                                                        switch (childChild.Name.LocalName)
                                                                                        {
                                                                                            case "Sph":
                                                                                                obj_cv5000.r.Sph = childChild.Value?.Trim();
                                                                                                break;
                                                                                            case "Cyl":
                                                                                                obj_cv5000.r.Cyl = childChild.Value?.Trim();
                                                                                                break;
                                                                                            case "Axis":
                                                                                                obj_cv5000.r.Axis = childChild.Value?.Trim();
                                                                                                break;
                                                                                            case "HPri":
                                                                                                obj_cv5000.r.HPri = childChild.Value?.Trim();
                                                                                                break;
                                                                                            case "HBase":
                                                                                                obj_cv5000.r.HBase = childChild.Value?.Trim();
                                                                                                break;
                                                                                            case "VPri":
                                                                                                obj_cv5000.r.VPri = childChild.Value?.Trim();
                                                                                                break;
                                                                                            case "VBase":
                                                                                                obj_cv5000.r.VBase = childChild.Value?.Trim();
                                                                                                break;
                                                                                            case "Prism":
                                                                                                obj_cv5000.r.Prism = childChild.Value?.Trim();
                                                                                                break;
                                                                                            case "Angle":
                                                                                                obj_cv5000.r.Angle = childChild.Value?.Trim();
                                                                                                break;
                                                                                        }
                                                                                    }
                                                                                    break;
                                                                                case "L":
                                                                                    foreach (var childChild in patientChild.Elements())
                                                                                    {
                                                                                        switch (childChild.Name.LocalName)
                                                                                        {
                                                                                            case "Sph":
                                                                                                obj_cv5000.l.Sph = childChild.Value?.Trim();
                                                                                                break;
                                                                                            case "Cyl":
                                                                                                obj_cv5000.l.Cyl = childChild.Value?.Trim();
                                                                                                break;
                                                                                            case "Axis":
                                                                                                obj_cv5000.l.Axis = childChild.Value?.Trim();
                                                                                                break;
                                                                                            case "HPri":
                                                                                                obj_cv5000.l.HPri = childChild.Value?.Trim();
                                                                                                break;
                                                                                            case "HBase":
                                                                                                obj_cv5000.l.HBase = childChild.Value?.Trim();
                                                                                                break;
                                                                                            case "VPri":
                                                                                                obj_cv5000.l.VPri = childChild.Value?.Trim();
                                                                                                break;
                                                                                            case "VBase":
                                                                                                obj_cv5000.l.VBase = childChild.Value?.Trim();
                                                                                                break;
                                                                                            case "Prism":
                                                                                                obj_cv5000.l.Prism = childChild.Value?.Trim();
                                                                                                break;
                                                                                            case "Angle":
                                                                                                obj_cv5000.l.Angle = childChild.Value?.Trim();
                                                                                                break;
                                                                                        }
                                                                                    }
                                                                                    break;
                                                                            }
                                                                        }break;
                                                                    case "PD":
                                                                        foreach (var paChild in rererefactChild.Elements())
                                                                        {
                                                                            switch (paChild.Name.LocalName)
                                                                            {
                                                                                case "R":
                                                                                    obj_cv5000.pd.R = paChild.Value?.Trim();
                                                                                    break;
                                                                                case "L":
                                                                                    obj_cv5000.pd.L = paChild.Value?.Trim();
                                                                                    break;
                                                                                case "B":
                                                                                    obj_cv5000.pd.B = paChild.Value?.Trim();
                                                                                    break;
                                                                            }
                                                                        }
                                                                        break;
                                                                }
                                                            }
                                                                break;
                                                       
                                                    }
                                                }
                                                break;
                                            
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void ShowCV5000Message(CV5000 obj_cv5000)
        {
            StringBuilder message = new StringBuilder();

            // Datos de Ophthalmology
            message.AppendLine("Ophthalmology Data:");
            message.AppendLine($"- Common:");
            message.AppendLine($"  - Company: {obj_cv5000.common?.Company}");
            message.AppendLine($"  - ModelName: {obj_cv5000.common?.ModelName}");
            message.AppendLine($"  - MachineNo: {obj_cv5000.common?.MachineNo}");
            message.AppendLine($"  - ROMVersion: {obj_cv5000.common?.ROMVersion}");
            message.AppendLine($"  - Version: {obj_cv5000.common?.Version}");
            message.AppendLine($"  - Date: {obj_cv5000.common?.Date?.ToString("yyyy-MM-dd")}");
            message.AppendLine($"  - Time: {obj_cv5000.common?.Time?.ToString("HH:mm:ss")}"); 
            message.AppendLine($"  - Duration: {obj_cv5000?.common?.Duration?.ToString("HH:mm:ss")}");

            message.AppendLine("Measure Data:");
            message.AppendLine($"- Measure Type: {obj_cv5000?.measure?.Type}");
            message.AppendLine($"- Measure TypeName: {obj_cv5000?.measure?.TypeName}");

            // Datos de RefractionTest
            message.AppendLine("RefractionTest Data:");
            message.AppendLine($"- Type: {obj_cv5000?.measure.Type}");

            // Datos de ExamDistance
            message.AppendLine("ExamDistance Data:");
            message.AppendLine($"- Distance: {obj_cv5000?.measure.Distance}");

            // Datos de Right Eye (R)
            message.AppendLine("Right Eye (R) Data:");
            message.AppendLine($"- Sphere: {obj_cv5000?.r.Sph}");
            message.AppendLine($"- Cylinder: {obj_cv5000?.r?.Cyl}");
            message.AppendLine($"- Axis: {obj_cv5000?.r?.Axis}");
            message.AppendLine($"- HPri: {obj_cv5000?.r?.HPri}");
            message.AppendLine($"- HBase: {obj_cv5000?.r?.HBase}");
            message.AppendLine($"- VPri: {obj_cv5000?.r?.VPri}");
            message.AppendLine($"- VBase: {obj_cv5000?.r?.VBase}");
            message.AppendLine($"- Prism: {obj_cv5000?.r?.Prism}");
            message.AppendLine($"- Angle: {obj_cv5000?.r?.Angle}");
            message.AppendLine($"- Unit: {obj_cv5000?.r?.Unit}");

            // Datos de Left Eye (L)
            message.AppendLine("Left Eye (L) Data:");
            message.AppendLine($"- Sphere: {obj_cv5000?.l?.Sph}");
            message.AppendLine($"- Cylinder: {obj_cv5000?.l?.Cyl}");
            message.AppendLine($"- Axis: {obj_cv5000?.l?.Axis}");
            message.AppendLine($"- HPri: {obj_cv5000?.l?.HPri}");
            message.AppendLine($"- HBase: {obj_cv5000?.l?.HBase}");
            message.AppendLine($"- VPri: {obj_cv5000?.l?.VPri}");
            message.AppendLine($"- VBase: {obj_cv5000?.l?.VBase}");
            message.AppendLine($"- Prism: {obj_cv5000?.l?.Prism}");
            message.AppendLine($"- Angle: {obj_cv5000?.l?.Angle}");
            message.AppendLine($"- Unit: {obj_cv5000?.l?.Unit}");


            // Datos de PD
            message.AppendLine("PD Data:");
            message.AppendLine($"- Right Eye (R): {obj_cv5000?.pd?.R}");
            message.AppendLine($"- Left Eye (L): {obj_cv5000?.pd?.L}");
            message.AppendLine($"- B: {obj_cv5000?.pd?.B}");

            // Mostrar el mensaje en un cuadro de mensaje (MessageBox) o en la consola
            MessageBox.Show(message.ToString(), "Datos del CV5000");
            //Console.WriteLine(message.ToString()); // Usar en caso de aplicaciones de consola
        }

        private void ExtractDataTRK2P(XElement element, TRK2P obj_trk2p)
        {
            // Definir los espacios de nombres basados en los prefijos del XML
            XNamespace nsCommon = "http://www.joia.or.jp/standardized/namespaces/Common";
            XNamespace nsREF = "http://www.joia.or.jp/standardized/namespaces/REF";
            XNamespace nsKM = "http://www.joia.or.jp/standardized/namespaces/KM";
            XNamespace nsTM = "http://www.joia.or.jp/standardized/namespaces/TM";

            // Asegurarse de que "element" no es null antes de buscar los descendientes
            if (element != null)
            {
                // Buscar elementos "Measure" con el espacio de nombres "nsREF"
                var listMeasure = element.Descendants(nsREF + "Measure");
                // Verificar si se encontraron elementos "Measure"
                if (listMeasure.Any())
                {
                    // Iterar sobre cada elemento "Measure"
                    foreach (var measureElement in listMeasure)
                    {
                        // Iterar sobre los elementos hijos dentro de "Measure"
                        foreach (var childElement in measureElement.Elements())
                        {
                            // Asignar valores según el nombre de cada hijo de "Measure"
                            if (childElement.Name == nsREF + "VD")
                            {
                                obj_trk2p.measure.VD = childElement.Value?.Trim();
                            }
                            else if (childElement.Name == nsREF + "Type")
                            {
                                obj_trk2p.measure.Type = childElement.Value?.Trim();
                            }
                            else if (childElement.Name == nsREF + "DiopterStep")
                            {
                                obj_trk2p.measure.DiopterStep = childElement.Value?.Trim();
                            }
                            else if (childElement.Name == nsREF + "AxisStep")
                            {
                                obj_trk2p.measure.AxisStep = childElement.Value?.Trim();
                            }
                            else if (childElement.Name == nsREF + "CylinderMode")
                            {
                                obj_trk2p.measure.CylinderMode = childElement.Value?.Trim();
                            }
                        }
                    }
                }
                // Obtener el elemento <nsREF:REF>
                var refElement = element.Descendants().FirstOrDefault(x => x.Name.LocalName == "REF");

                if (refElement != null)
                {
                    // Procesar la parte derecha (R)
                    var rElement = refElement.Element("{http://www.joia.or.jp/standardized/namespaces/REF}R");
                    if (rElement != null)
                    {
                        var rLists = rElement.Descendants("{http://www.joia.or.jp/standardized/namespaces/REF}List");
                        foreach (var list in rLists)
                        {
                            var no = list.Attribute("No")?.Value; // Obtener el atributo 'No'

                            // Extraer valores de cada lista
                            var sphere = list.Element("{http://www.joia.or.jp/standardized/namespaces/REF}Sphere")?.Value?.Trim();
                            var cylinder = list.Element("{http://www.joia.or.jp/standardized/namespaces/REF}Cylinder")?.Value?.Trim();
                            var axis = list.Element("{http://www.joia.or.jp/standardized/namespaces/REF}Axis")?.Value?.Trim();
                            var se = list.Element("{http://www.joia.or.jp/standardized/namespaces/REF}SE")?.Value?.Trim();

                            //if (no == "1")
                            //{
                            //    obj_trk2p.list.Sphere = sphere;
                            //    obj_trk2p.list.Cylinder = cylinder;
                            //    obj_trk2p.list.Axis = axis;
                            //    obj_trk2p.list.SE = se;
                            //}
                            //else if (no == "2")
                            //{
                            //    obj_trk2p.R2_Sphere = sphere;
                            //    obj_trk2p.R2_Cylinder = cylinder;
                            //    obj_trk2p.R2_Axis = axis;
                            //    obj_trk2p.R2_SE = se;
                            //}
                            //else if (no == "3")
                            //{
                            //    obj_trk2p.R3_Sphere = sphere;
                            //    obj_trk2p.R3_Cylinder = cylinder;
                            //    obj_trk2p.R3_Axis = axis;
                            //    obj_trk2p.R3_SE = se;
                            //}
                        }

                        // Extraer valores de la parte "Median"
                        var median = rElement.Element("{http://www.joia.or.jp/standardized/namespaces/REF}Median");
                        if (median != null)
                        {
                            obj_trk2p.median.Sphere = median.Element("{http://www.joia.or.jp/standardized/namespaces/REF}Sphere")?.Value?.Trim();
                            obj_trk2p.median.Cylinder = median.Element("{http://www.joia.or.jp/standardized/namespaces/REF}Cylinder")?.Value?.Trim();
                            obj_trk2p.median.Axis = median.Element("{http://www.joia.or.jp/standardized/namespaces/REF}Axis")?.Value?.Trim();
                            obj_trk2p.median.SE = median.Element("{http://www.joia.or.jp/standardized/namespaces/REF}SE")?.Value?.Trim();
                        }
                    }

                    // Procesar la parte izquierda (L)
                    var lElement = refElement.Element("{http://www.joia.or.jp/standardized/namespaces/REF}L");
                    if (lElement != null)
                    {
                        var lLists = lElement.Descendants("{http://www.joia.or.jp/standardized/namespaces/REF}List");
                        foreach (var list in lLists)
                        {
                            var no = list.Attribute("No")?.Value; // Obtener el atributo 'No'

                            // Extraer valores de cada lista
                            var sphere = list.Element("{http://www.joia.or.jp/standardized/namespaces/REF}Sphere")?.Value?.Trim();
                            var cylinder = list.Element("{http://www.joia.or.jp/standardized/namespaces/REF}Cylinder")?.Value?.Trim();
                            var axis = list.Element("{http://www.joia.or.jp/standardized/namespaces/REF}Axis")?.Value?.Trim();
                            var se = list.Element("{http://www.joia.or.jp/standardized/namespaces/REF}SE")?.Value?.Trim();

                            //// Asignar valores a obj_trk2p según corresponda
                            //if (no == "1")
                            //{
                            //    obj_trk2p.L1_Sphere = sphere;
                            //    obj_trk2p.L1_Cylinder = cylinder;
                            //    obj_trk2p.L1_Axis = axis;
                            //    obj_trk2p.L1_SE = se;
                            //}
                            //else if (no == "2")
                            //{
                            //    obj_trk2p.L2_Sphere = sphere;
                            //    obj_trk2p.L2_Cylinder = cylinder;
                            //    obj_trk2p.L2_Axis = axis;
                            //    obj_trk2p.L2_SE = se;
                            //}
                            //else if (no == "3")
                            //{
                            //    obj_trk2p.L3_Sphere = sphere;
                            //    obj_trk2p.L3_Cylinder = cylinder;
                            //    obj_trk2p.L3_Axis = axis;
                            //    obj_trk2p.L3_SE = se;
                            //}
                        }

                        // Extraer valores de la parte "Median"
                        var median = lElement.Element("{http://www.joia.or.jp/standardized/namespaces/REF}Median");
                        if (median != null)
                        {
                            obj_trk2p.median.Sphere = median.Element("{http://www.joia.or.jp/standardized/namespaces/REF}Sphere")?.Value?.Trim();
                            obj_trk2p.median.Cylinder = median.Element("{http://www.joia.or.jp/standardized/namespaces/REF}Cylinder")?.Value?.Trim();
                            obj_trk2p.median.Axis = median.Element("{http://www.joia.or.jp/standardized/namespaces/REF}Axis")?.Value?.Trim();
                            obj_trk2p.median.SE = median.Element("{http://www.joia.or.jp/standardized/namespaces/REF}SE")?.Value?.Trim();
                        }
                    }





                }
            }
        }
        private void ShowMessageTRK2P(TRK2P obj_trk2p)
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine("Ophthalmology Data:");
            message.AppendLine($"Common:");
            message.AppendLine($"- Company: {obj_trk2p?.common?.Company}");
            message.AppendLine($"- ModelName: {obj_trk2p?.common?.ModelName}");
            message.AppendLine($"- MachineNo: {obj_trk2p?.common?.MachineNo}");
            message.AppendLine($"- ROMVersion: {obj_trk2p?.common?.ROMVersion}");
            message.AppendLine($"- Version: {obj_trk2p?.common?.Version}");
            message.AppendLine($"- Date: {obj_trk2p?.common?.Date?.ToString("yyyy-MM-dd")}");
            message.AppendLine($"- Time: {obj_trk2p?.common?.Time?.ToString("HH:mm:ss")}");

            message.AppendLine($"Measure {obj_trk2p?.measure.Type}");
            message.AppendLine($"VD: {obj_trk2p?.measure.VD}");
            message.AppendLine($"DiopterStep: {obj_trk2p?.measure.DiopterStep}");
            message.AppendLine($"AxisStep: {obj_trk2p?.measure.AxisStep}");
            message.AppendLine($"CylinderMode: {obj_trk2p?.measure.CylinderMode}");

            message.AppendLine($"Ref: No {obj_trk2p?.list.No}");
            message.AppendLine($"Sphere: {obj_trk2p?.list.Sphere}"); 
            message.AppendLine($"Cylinder: {obj_trk2p?.list.Cylinder}");
            message.AppendLine($"Axis: {obj_trk2p?.list.Axis}");
            message.AppendLine($"CataractMode: {obj_trk2p?.list.CataractMode}");
            message.AppendLine($"IOLMode: {obj_trk2p?.list.IOLMode}");
            message.AppendLine($"ConfidenceIndex: {obj_trk2p?.list.ConfidenceIndex}");

            message.AppendLine($"Ref: L {obj_trk2p?.list.No}");
            message.AppendLine($"Sphere {obj_trk2p?.list.Sphere}");
            message.AppendLine($"Cylinder {obj_trk2p?.list.Cylinder}");
            message.AppendLine($"Axis {obj_trk2p?.list.Axis}");
            message.AppendLine($"CataractMode {obj_trk2p?.list.CataractMode}");
            message.AppendLine($"IOLMode {obj_trk2p?.list.IOLMode}");
            message.AppendLine($"ConfidenceIndex {obj_trk2p?.list.ConfidenceIndex}");

            message.AppendLine($"PD: WorkingDistance {obj_trk2p?.pd.WorkingDistance}");
            message.AppendLine($"PD: Distance {obj_trk2p?.pd.Distance}");
            message.AppendLine($"PD: Near {obj_trk2p?.pd.Near}");

            message.AppendLine($"Type: {obj_trk2p?.measure.Type}");
            message.AppendLine($"Radius: {obj_trk2p?.r1.Radius}");
            message.AppendLine($"Power: {obj_trk2p?.r1.Power}");
            message.AppendLine($"Axis: {obj_trk2p?.r1.Axis}");

            message.AppendLine($"Type: {obj_trk2p?.measure.Type}");
            message.AppendLine($"Measure: {obj_trk2p?.r1.Radius}");
            message.AppendLine($"Measure: {obj_trk2p?.r1.Power}");
            message.AppendLine($"Measure: {obj_trk2p?.r1.Axis}");

            message.AppendLine($"Type: {obj_trk2p?.confidence.R}");
            message.AppendLine($"Type: {obj_trk2p?.confidence.L}");

            message.AppendLine($"Type: {obj_trk2p?.tm.R}");
            message.AppendLine($"Type: {obj_trk2p?.tm.L}");

            //message.AppendLine($"Type: {obj_trk2p?.correctedIOP.Formula1.R}");
            //message.AppendLine($"Type: {obj_trk2p?.correctedIOP.Formula1.L}");

            message.AppendLine($"Type: {obj_trk2p?.tm.RLOrder}");
            message.AppendLine($"Type: {obj_trk2p?.tm.R}");
            message.AppendLine($"Type: {obj_trk2p?.tm.L}");

            //message.AppendLine($"Type: {obj_trk2p?.correctedIOP.R}");
            //message.AppendLine($"Type: {obj_trk2p?.correctedIOP.L}");

            //message.AppendLine($"Type: {obj_trk2p?.cct.RLOrder}");
            //message.AppendLine($"Type: {obj_trk2p?.cct.R}");
            //message.AppendLine($"Type: {obj_trk2p?.cct.L}");


            MessageBox.Show(message.ToString(), "Datos del TRK2P");
        }
        // Método común para extraer datos generales compartidos entre los modelos
        private void ExtractCommons(XElement element, AparatosTopcon _ObjToFill)
        {                    
            
            //var listComon = element.Descendants().Where(x => x.Name == "Common");

            if (element.Name.LocalName == "Ophthalmology")
            {
                foreach (var childElement in element.Elements())
                {
                    if (childElement.Name.LocalName == "Common")
                    {
                        foreach (var commonChild in childElement.Elements())
                        {
                            switch (commonChild.Name.LocalName)
                            {
                                case "ModelName":
                                    _ObjToFill.common.ModelName = commonChild.Value?.Trim();
                                    break;
                                case "Company":
                                    _ObjToFill.common.Company = commonChild.Value?.Trim();
                                    break;
                                case "MachineNo":
                                    if (int.TryParse(commonChild.Value?.Trim(), out int machineNo))
                                        _ObjToFill.common.MachineNo = machineNo;
                                    break;
                                case "ROMVersion":
                                    _ObjToFill.common.ROMVersion = commonChild.Value?.Trim();
                                    break;
                                case "Version":
                                    _ObjToFill.common.Version = commonChild.Value?.Trim();
                                    break;
                                case "Time":
                                    if (DateTime.TryParse(commonChild.Value?.Trim(), out DateTime time))
                                        _ObjToFill.common.Time = time;
                                    break;
                                case "Date":
                                    if (DateTime.TryParse(commonChild.Value?.Trim(), out DateTime date))
                                        _ObjToFill.common.Date = date;
                                    break;
                                case "DateFormat":
                                    _ObjToFill.common.DateFormat = commonChild.Value?.Trim();
                                    break;
                                case "Duration":
                                    if (DateTime.TryParse(commonChild.Value?.Trim(), out DateTime duration))
                                        _ObjToFill.common.Duration = duration;
                                    break;

                                // Procesa los campos de "Patient"
                                case "Patient":
                                    foreach (var patientChild in commonChild.Elements())
                                    {
                                        switch (patientChild.Name.LocalName)
                                        {
                                            case "No.":
                                                if (int.TryParse(patientChild.Value?.Trim(), out int patientNo))
                                                    _ObjToFill.patient.No = patientNo;
                                                break;
                                            case "ID":
                                                if (int.TryParse(patientChild.Value?.Trim(), out int patientID))
                                                    _ObjToFill.patient.ID = patientID;
                                                break;
                                            case "FirstName":
                                                _ObjToFill.patient.FirstName = patientChild.Value?.Trim();
                                                break;
                                            case "MiddleName":
                                                _ObjToFill.patient.MiddleName = patientChild.Value?.Trim();
                                                break;
                                            case "LastName":
                                                _ObjToFill.patient.LastName = patientChild.Value?.Trim();
                                                break;
                                            case "Sex":
                                                _ObjToFill.patient.Sex = patientChild.Value?.Trim();
                                                break;
                                            case "Age":
                                                if (int.TryParse(patientChild.Value?.Trim(), out int age))
                                                    _ObjToFill.patient.Age = age;
                                                break;
                                            case "DOB":
                                                _ObjToFill.patient.DOB = patientChild.Value?.Trim();
                                                break;
                                            case "NameJ1":
                                                _ObjToFill.patient.NameJ1 = patientChild.Value?.Trim();
                                                break;
                                            case "NameJ2":
                                                _ObjToFill.patient.NameJ2 = patientChild.Value?.Trim();
                                                break;
                                        }
                                    }
                                    break;

                                // Campos del operador
                                case "OperatorNo.":
                                    if (int.TryParse(commonChild.Value?.Trim(), out int operatorNo))
                                        _ObjToFill.Operator.No = operatorNo;
                                    break;
                                case "OperatorID":
                                    if (int.TryParse(commonChild.Value?.Trim(), out int operatorID))
                                        _ObjToFill.Operator.ID = operatorID;
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
