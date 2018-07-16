using Google.Protobuf;
using Google.Protobuf.Examples.AddressBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Serialize and parse it.  Make sure to parse from an InputStream, not
            // directly from a ByteString, so that CodedInputStream uses buffered
            // reading.
            AddressBook l1 = new AddressBook();
            l1.People.Add(new Person() { Id = 1, Name = "ABC", Email = "abc@gmail.com" });

            var clone = l1.Clone();
            byte[] bytes = l1.ToByteArray();
            string json1 = l1.ToString();
            string json2 = JsonFormatter.Default.Format(l1);
            var writer = new StringWriter();
            JsonFormatter.Default.Format(l1, writer);
            string json3 = writer.ToString();

            byte[] buf = null;

            using (var ms = new MemoryStream())
            using (var output = new CodedOutputStream(ms))
            {
                //////uint tag = WireFormat.MakeTag(1, WireFormat.WireType.LengthDelimited);
                //////output.WriteRawVarint32(tag);
                //////output.WriteRawVarint32(0x7FFFFFFF);
                //////output.WriteRawBytes(new byte[32]); // Pad with a few random bytes.
                //////output.Flush();
                //////ms.Position = 0;

                ////output.WriteTag(1, WireFormat.WireType.Varint);
                //output.WriteInt32(99);
                ////output.WriteTag(2, WireFormat.WireType.Varint);
                //output.WriteInt32(123);

                //output.WriteRawVarint32(0);
                output.WriteRawVarint32(34567);

                l1.WriteTo(output);

                output.Flush();

                buf = ms.ToArray();
            }

            int tag = 0;
            AddressBook l2 = null;
            if (buf != null && buf.Length > 0)
            {
                using (var input = new CodedInputStream(buf))
                {
                    tag = input.ReadInt32();
                    //uint tag2 = input.ReadTag();
                    try
                    {
                        l2 = AddressBook.Parser.ParseFrom(input);
                    }
                    catch (Exception ex)
                    {
                        string log = ex.Message;
                    }
                }
            }



            ////////////////////////////////////////////////

            Console.WriteLine("Enter to exit ...");
            Console.ReadLine();
        }
    }
}
