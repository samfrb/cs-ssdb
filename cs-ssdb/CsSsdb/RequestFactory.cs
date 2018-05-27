//using System.IO;
//using System.Text;
//
//namespace cs_ssdb
//{
//    public class RequestFactory : IRequestFactory
//    {
//        private const byte NewLine = (byte) '\n';
//        
//        public byte[] GetSetRequest(string key, string value)
//        {
//            MemoryStream buf = new MemoryStream();
//            
//            byte[] lenc = Encoding.Default.GetBytes("3");
//            buf.Write(lenc, 0, lenc.Length);
//            buf.WriteByte(NewLine);
//            
//            byte[] lencd = Encoding.Default.GetBytes("set");
//            buf.Write(lencd, 0, lencd.Length);
//            buf.WriteByte(NewLine);
//            
//            // key
//            byte[] len = Encoding.Default.GetBytes(p.Length.ToString()); // ??
//                
//            buf.Write(len, 0, len.Length);
//            buf.WriteByte(NewLine);
//                
//            buf.Write(p, 0, p.Length);
//            buf.WriteByte(NewLine);
//            
//            // value
//            
//            foreach(byte[] p in args) 
//            {
//                byte[] len = Encoding.Default.GetBytes(p.Length.ToString()); // ??
//                
//                buf.Write(len, 0, len.Length);
//                buf.WriteByte(NewLine);
//                
//                buf.Write(p, 0, p.Length);
//                buf.WriteByte(NewLine);
//            }
//            
//            buf.WriteByte((byte)'\n');
//
//            return buf.GetBuffer();
//        }
//    }
//}