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

            byte[] buf;

            using (var ms = new MemoryStream()) 
            using (var output = new CodedOutputStream(ms))
            {
                //////uint tag = WireFormat.MakeTag(1, WireFormat.WireType.LengthDelimited);
                //////output.WriteRawVarint32(tag);
                //////output.WriteRawVarint32(0x7FFFFFFF);
                //////output.WriteRawBytes(new byte[32]); // Pad with a few random bytes.
                //////output.Flush();
                //////ms.Position = 0;
                

                //output.WriteTag(1, WireFormat.WireType.Varint);
                output.WriteInt32(99);
                //output.WriteTag(2, WireFormat.WireType.Varint);
                output.WriteInt32(123);

                l1.WriteTo(output);

                output.Flush();

                buf = ms.ToArray();
            }

            if (buf != null && buf.Length > 0) {
                using (var input = new CodedInputStream(buf))
                {
                    uint tag1 = input.ReadTag();
                    uint tag2 = input.ReadTag();
                }
            }



            ////////////////////////////////////////////////

            Console.WriteLine("Enter to exit ...");
            Console.ReadLine();
        }
    }
}
