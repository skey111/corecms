﻿using System.Collections.Generic;

namespace CoreArea.Layouts.IpDb
{

    public class District
    {

        /**
         * @var Reader
         */
        private readonly Reader reader;

        public District(string name)  {
            reader = new Reader(name);
        }

        public string[] find(string addr, string language)  {
            return reader.find(addr, language);
        }

        public Dictionary<string, string> findMap(string addr, string language)  {
            var data = reader.find(addr, language);
            if (data == null) {
                return null;
            }

            var m = new Dictionary<string, string>();

            var fields = reader.getSupportFields();

            for (int i = 0, l = data.Length; i<l; i++) {
                m.Add(fields[i], data[i]);
            }

            return m;
        }

        public DistrictInfo findInfo(string addr, string language)  {

            var data = reader.find(addr, language);
            if (data == null) {
                return null;
            }

            return new DistrictInfo(data);
        }

        public bool isIPv4()
        {
            return (reader.getMeta().IPVersion & 0x01) == 0x01;
        }

        public bool isIPv6()
        {
            return (reader.getMeta().IPVersion & 0x02) == 0x02;
        }

        public string[] fields()
        {
            return reader.getSupportFields();
        }

        public int buildTime()
        {
            return reader.getBuildUTCTime();
        }
    }
}
