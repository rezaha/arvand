using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml.Linq;

namespace Arvand.Common
{
    // A real XLSX package using the framework's ZIP/XML APIs, without Office
    // automation or an unbundled EPPlus dependency. Values are literal text.
    public static class PortalWorkbook
    {
        private static readonly XNamespace Sheet = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
        public static byte[] Build(string[] headers, IEnumerable<string[]> records)
        {
            if (headers == null || headers.Length == 0) throw new ArgumentException("Headers are required.", "headers");
            if (records == null) throw new ArgumentNullException("records");
            var rows = new XElement(Sheet + "sheetData");
            int row = 1;
            rows.Add(Row(headers, row++, true));
            foreach (var values in records)
            {
                if (values == null || values.Length != headers.Length) throw new ArgumentException("Column count mismatch.", "records");
                rows.Add(Row(values, row++, false));
            }
            using (var output = new MemoryStream())
            {
                using (var archive = new ZipArchive(output, ZipArchiveMode.Create, true))
                {
                    Add(archive, "[Content_Types].xml", XDocument.Parse(@"<Types xmlns='http://schemas.openxmlformats.org/package/2006/content-types'><Default Extension='rels' ContentType='application/vnd.openxmlformats-package.relationships+xml'/><Default Extension='xml' ContentType='application/xml'/><Override PartName='/xl/workbook.xml' ContentType='application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml'/><Override PartName='/xl/worksheets/sheet1.xml' ContentType='application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml'/><Override PartName='/xl/styles.xml' ContentType='application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml'/></Types>"));
                    Add(archive, "_rels/.rels", XDocument.Parse(@"<Relationships xmlns='http://schemas.openxmlformats.org/package/2006/relationships'><Relationship Id='rId1' Type='http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument' Target='xl/workbook.xml'/></Relationships>"));
                    Add(archive, "xl/workbook.xml", XDocument.Parse(@"<workbook xmlns='http://schemas.openxmlformats.org/spreadsheetml/2006/main' xmlns:r='http://schemas.openxmlformats.org/officeDocument/2006/relationships'><sheets><sheet name='درخواست‌های تعاونی' sheetId='1' r:id='rId1'/></sheets></workbook>"));
                    Add(archive, "xl/_rels/workbook.xml.rels", XDocument.Parse(@"<Relationships xmlns='http://schemas.openxmlformats.org/package/2006/relationships'><Relationship Id='rId1' Type='http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet' Target='worksheets/sheet1.xml'/><Relationship Id='rId2' Type='http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles' Target='styles.xml'/></Relationships>"));
                    Add(archive, "xl/styles.xml", XDocument.Parse(@"<styleSheet xmlns='http://schemas.openxmlformats.org/spreadsheetml/2006/main'><fonts count='2'><font><sz val='11'/><name val='Tahoma'/></font><font><b/><sz val='11'/><name val='Tahoma'/></font></fonts><fills count='2'><fill><patternFill patternType='none'/></fill><fill><patternFill patternType='gray125'/></fill></fills><borders count='1'><border><left/><right/><top/><bottom/><diagonal/></border></borders><cellStyleXfs count='1'><xf numFmtId='0' fontId='0' fillId='0' borderId='0'/></cellStyleXfs><cellXfs count='2'><xf numFmtId='49' fontId='0' fillId='0' borderId='0' xfId='0' applyNumberFormat='1' applyAlignment='1'><alignment horizontal='center' vertical='center' readingOrder='2'/></xf><xf numFmtId='49' fontId='1' fillId='0' borderId='0' xfId='0' applyAlignment='1'><alignment horizontal='center' readingOrder='2'/></xf></cellXfs><cellStyles count='1'><cellStyle name='Normal' xfId='0' builtinId='0'/></cellStyles></styleSheet>"));
                    Add(archive, "xl/worksheets/sheet1.xml", new XDocument(new XElement(Sheet + "worksheet",
                        new XElement(Sheet + "sheetViews", new XElement(Sheet + "sheetView", new XAttribute("workbookViewId", "0"), new XAttribute("rightToLeft", "1"))),
                        new XElement(Sheet + "cols", new XElement(Sheet + "col", new XAttribute("min", "1"), new XAttribute("max", headers.Length), new XAttribute("width", "23"), new XAttribute("customWidth", "1"))), rows)));
                }
                return output.ToArray();
            }
        }
        private static XElement Row(string[] values, int number, bool header)
        {
            return new XElement(Sheet + "row", new XAttribute("r", number), values.Select((value, index) =>
                new XElement(Sheet + "c", new XAttribute("r", Column(index + 1) + number.ToString(CultureInfo.InvariantCulture)),
                    new XAttribute("t", "inlineStr"), new XAttribute("s", header ? "1" : "0"),
                    new XElement(Sheet + "is", new XElement(Sheet + "t", new XAttribute(XNamespace.Xml + "space", "preserve"), value ?? "")))));
        }
        private static string Column(int number)
        {
            var result = "";
            while (number > 0) { number--; result = (char)('A' + number % 26) + result; number /= 26; }
            return result;
        }
        private static void Add(ZipArchive archive, string name, XDocument document)
        {
            using (var stream = archive.CreateEntry(name).Open()) document.Save(stream);
        }
    }
}
