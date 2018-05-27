using System;

namespace CsSsdb.Parsing
{
    public static class ResponseParser
    {
        /// <summary>
        /// Reads the size field of a Block from the given array. If it doesn't encouter
        /// the '\n' before the end of the array or if the current character is not a
        /// number or a '\n' it will return -1.
        /// </summary>
        /// <param name="blockBytes">The array of bytes to parse</param>
        /// <param name="offset">The offset at which to start parsing</param>
        /// <param name="stopIndex">The index of the last byte read</param>
        /// <returns>Returns the size if parsing was correct, otherwise -1</returns>
        /// <exception cref="IndexOutOfRangeException">If the offset is out of bounds</exception>
        public static int ReadSize(byte[] blockBytes, int offset, out int stopIndex)
        {
            if (offset < 0 || offset >= blockBytes.Length)
                throw new IndexOutOfRangeException("The offset must be in the bound of the array");

            int size = 0;
            stopIndex = offset;

            for (int i = offset; i < blockBytes.Length; i++, offset++)
            {
                byte current = blockBytes[i];

                if (current >= '0' && current <= '9')
                {
                    size = size * 10 + (current - '0');
                }
                else if (current == '\n')
                {
                    return size;
                }
                else
                {
                    return -1;
                }

                stopIndex++;
            }

            return -1;
        }
        
        /*private static int memchr(byte[] bs, byte b, int offset)
        {
            for (int i = offset; i < bs.Length; i++)
            {
                if (bs[i] == b)
                {
                    return i;
                }
            }

            return -1;
        }*/

        /*public static Block ReadBlock(byte[] blockBytes)
        {
            
            int size = ReadSize(blockBytes);
        }*/

        /*public static byte[] ReadData(int size)
        {
            
        }*/

        /*public static Response Parse(byte[] recv_buf)
        {
            int index = 0;
            
            List<Block> blocks = new List<Block>();
            
            while (true)
            {

                Block rdBlock = ReadBlock(recv_buf);
            }

            List<byte[]> list = new List<byte[]>();
            //byte[] buf = recv_buf.GetBuffer();
            byte[] buf = new byte[recv_buf.Length];
            

            int idx = 0;
            
            while(true) 
            {
                // look for the index of the newline
                int pos = memchr(buf, (byte)'\n', idx);
                
                if(pos == -1) 
                    break;
                
                if(pos == idx || (pos == idx + 1 && buf[idx] == '\r')) 
                {
                    idx += 1; // if '\r', next time will skip '\n'
                    
                    // ignore empty leading lines
                    if(list.Count == 0) 
                    {
                        continue;
                    } 
                    else 
                    {
                        int left = (int)recv_buf.Length - idx;
                        recv_buf = new MemoryStream(8192);
                        if(left > 0) {
                            recv_buf.Write(buf, idx, left);
                        }
                        return list;
                    }
                }
                
                byte[] lens = new byte[pos - idx];
                Array.Copy(buf, idx, lens, 0, lens.Length);
                
                int len = Int32.Parse(Encoding.Default.GetString(lens));

                idx = pos + 1;
                
                if(idx + len >= recv_buf.Length) {
                    break;
                }
                
                byte[] data = new byte[len];
                Array.Copy(buf, idx, data, 0, data.Length);

                idx += len + 1; // skip '\n'
                list.Add(data);
            }
            return null;
        }
    }

    public class Block
    {
    }

    public class Response
    {
        
    }*/
    }
}