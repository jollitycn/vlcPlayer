namespace CJBasic.Security
{
    using System;
    using System.Text;

    public class DesEncryption
    {
        private uint[] bits_tb64;
        private CJBasic.Security.DesStrategy desStrategy;
        private int[] expt_tb;
        private int[] fst_change_tb;
        private string iniVector;
        private string key;
        private uint[][] keyArray;
        private int[] keychoose;
        private int[] keyleft;
        private int[] keyright;
        private uint[] leftandtab;
        private int[] lefttable;
        private int[] lst_change_tb;
        private int[] mid_change_tb32;
        private int[,] SP;

        public DesEncryption()
        {
            this.keyArray = new uint[0x10][];
            this.fst_change_tb = new int[] { 
                0x3a, 50, 0x2a, 0x22, 0x1a, 0x12, 10, 2, 60, 0x34, 0x2c, 0x24, 0x1c, 20, 12, 4,
                0x3e, 0x36, 0x2e, 0x26, 30, 0x16, 14, 6, 0x40, 0x38, 0x30, 40, 0x20, 0x18, 0x10, 8,
                0x39, 0x31, 0x29, 0x21, 0x19, 0x11, 9, 1, 0x3b, 0x33, 0x2b, 0x23, 0x1b, 0x13, 11, 3,
                0x3d, 0x35, 0x2d, 0x25, 0x1d, 0x15, 13, 5, 0x3f, 0x37, 0x2f, 0x27, 0x1f, 0x17, 15, 7
            };
            this.lst_change_tb = new int[] { 
                40, 8, 0x30, 0x10, 0x38, 0x18, 0x40, 0x20, 0x27, 7, 0x2f, 15, 0x37, 0x17, 0x3f, 0x1f,
                0x26, 6, 0x2e, 14, 0x36, 0x16, 0x3e, 30, 0x25, 5, 0x2d, 13, 0x35, 0x15, 0x3d, 0x1d,
                0x24, 4, 0x2c, 12, 0x34, 20, 60, 0x1c, 0x23, 3, 0x2b, 11, 0x33, 0x13, 0x3b, 0x1b,
                0x22, 2, 0x2a, 10, 50, 0x12, 0x3a, 0x1a, 0x21, 1, 0x29, 9, 0x31, 0x11, 0x39, 0x19
            };
            this.mid_change_tb32 = new int[] { 
                0x10, 7, 20, 0x15, 0x1d, 12, 0x1c, 0x11, 1, 15, 0x17, 0x1a, 5, 0x12, 0x1f, 10,
                2, 8, 0x18, 14, 0x20, 0x1b, 3, 9, 0x13, 13, 30, 6, 0x16, 11, 4, 0x19
            };
            this.bits_tb64 = new uint[] { 
                0x80000000, 0x40000000, 0x20000000, 0x10000000, 0x8000000, 0x4000000, 0x2000000, 0x1000000, 0x800000, 0x400000, 0x200000, 0x100000, 0x80000, 0x40000, 0x20000, 0x10000,
                0x8000, 0x4000, 0x2000, 0x1000, 0x800, 0x400, 0x200, 0x100, 0x80, 0x40, 0x20, 0x10, 8, 4, 2, 1,
                0x80000000, 0x40000000, 0x20000000, 0x10000000, 0x8000000, 0x4000000, 0x2000000, 0x1000000, 0x800000, 0x400000, 0x200000, 0x100000, 0x80000, 0x40000, 0x20000, 0x10000,
                0x8000, 0x4000, 0x2000, 0x1000, 0x800, 0x400, 0x200, 0x100, 0x80, 0x40, 0x20, 0x10, 8, 4, 2, 1
            };
            this.expt_tb = new int[] { 
                0x20, 1, 2, 3, 4, 5, 4, 5, 6, 7, 8, 9, 8, 9, 10, 11,
                12, 13, 12, 13, 14, 15, 0x10, 0x11, 0x10, 0x11, 0x12, 0x13, 20, 0x15, 20, 0x15,
                0x16, 0x17, 0x18, 0x19, 0x18, 0x19, 0x1a, 0x1b, 0x1c, 0x1d, 0x1c, 0x1d, 30, 0x1f, 0x20, 1
            };
            this.SP = new int[,] { { 
                14, 0, 4, 15, 13, 7, 1, 4, 2, 14, 15, 2, 11, 13, 8, 1,
                3, 10, 10, 6, 6, 12, 12, 11, 5, 9, 9, 5, 0, 3, 7, 8,
                4, 15, 1, 12, 14, 8, 8, 2, 13, 4, 6, 9, 2, 1, 11, 7,
                15, 5, 12, 11, 9, 3, 7, 14, 3, 10, 10, 0, 5, 6, 0, 13
            }, { 
                15, 3, 1, 13, 8, 4, 14, 7, 6, 15, 11, 2, 3, 8, 4, 15,
                9, 12, 7, 0, 2, 1, 13, 10, 12, 6, 0, 9, 5, 11, 10, 5,
                0, 13, 14, 8, 7, 10, 11, 1, 10, 3, 4, 15, 13, 4, 1, 2,
                5, 11, 8, 6, 12, 7, 6, 12, 9, 0, 3, 5, 2, 14, 15, 9
            }, { 
                10, 13, 0, 7, 9, 0, 14, 9, 6, 3, 3, 4, 15, 6, 5, 10,
                1, 2, 13, 8, 12, 5, 7, 14, 11, 12, 4, 11, 2, 15, 8, 1,
                13, 1, 6, 10, 4, 13, 9, 0, 8, 6, 15, 9, 3, 8, 0, 7,
                11, 4, 1, 15, 2, 14, 12, 3, 5, 11, 10, 5, 14, 2, 7, 12
            }, { 
                7, 13, 13, 8, 14, 11, 3, 5, 0, 6, 6, 15, 9, 0, 10, 3,
                1, 4, 2, 7, 8, 2, 5, 12, 11, 1, 12, 10, 4, 14, 15, 9,
                10, 3, 6, 15, 9, 0, 0, 6, 12, 10, 11, 10, 7, 13, 13, 8,
                15, 9, 1, 4, 3, 5, 14, 11, 5, 12, 2, 7, 8, 2, 4, 14
            }, { 
                2, 14, 12, 11, 4, 2, 1, 12, 7, 4, 10, 7, 11, 13, 6, 1,
                8, 5, 5, 0, 3, 15, 15, 10, 13, 3, 0, 9, 14, 8, 9, 6,
                4, 11, 2, 8, 1, 12, 11, 7, 10, 1, 13, 14, 7, 2, 8, 13,
                15, 6, 9, 15, 12, 0, 5, 9, 6, 10, 3, 4, 0, 5, 14, 3
            }, { 
                12, 10, 1, 15, 10, 4, 15, 2, 9, 7, 2, 12, 6, 9, 8, 5,
                0, 6, 13, 1, 3, 13, 4, 14, 14, 0, 7, 11, 5, 3, 11, 8,
                9, 4, 14, 3, 15, 2, 5, 12, 2, 9, 8, 5, 12, 15, 3, 10,
                7, 11, 0, 14, 4, 1, 10, 7, 1, 6, 13, 0, 11, 8, 6, 13
            }, { 
                4, 13, 11, 0, 2, 11, 14, 7, 15, 4, 0, 9, 8, 1, 13, 10,
                3, 14, 12, 3, 9, 5, 7, 12, 5, 2, 10, 15, 6, 8, 1, 6,
                1, 6, 4, 11, 11, 13, 13, 8, 12, 1, 3, 4, 7, 10, 14, 7,
                10, 9, 15, 5, 6, 0, 8, 15, 0, 14, 5, 2, 9, 3, 2, 12
            }, { 
                13, 1, 2, 15, 8, 13, 4, 8, 6, 10, 15, 3, 11, 7, 1, 4,
                10, 12, 9, 5, 3, 6, 14, 11, 5, 0, 0, 14, 12, 9, 7, 2,
                7, 2, 11, 1, 4, 14, 1, 7, 9, 4, 12, 10, 14, 8, 2, 13,
                0, 15, 6, 12, 10, 9, 13, 0, 15, 3, 3, 5, 5, 6, 8, 11
            } };
            this.keyleft = new int[] { 
                0x39, 0x31, 0x29, 0x21, 0x19, 0x11, 9, 1, 0x3a, 50, 0x2a, 0x22, 0x1a, 0x12, 10, 2,
                0x3b, 0x33, 0x2b, 0x23, 0x1b, 0x13, 11, 3, 60, 0x34, 0x2c, 0x24
            };
            this.keyright = new int[] { 
                0x3f, 0x37, 0x2f, 0x27, 0x1f, 0x17, 15, 7, 0x3e, 0x36, 0x2e, 0x26, 30, 0x16, 14, 6,
                0x3d, 0x35, 0x2d, 0x25, 0x1d, 0x15, 13, 5, 0x1c, 20, 12, 4
            };
            this.lefttable = new int[] { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };
            uint[] numArray = new uint[3];
            numArray[1] = 0x80000000;
            numArray[2] = 0xc0000000;
            this.leftandtab = numArray;
            this.keychoose = new int[] { 
                14, 0x11, 11, 0x18, 1, 5, 3, 0x1c, 15, 6, 0x15, 10, 0x17, 0x13, 12, 4,
                0x1a, 8, 0x10, 7, 0x1b, 20, 13, 2, 0x29, 0x34, 0x1f, 0x25, 0x2f, 0x37, 30, 40,
                0x33, 0x2d, 0x21, 0x30, 0x2c, 0x31, 0x27, 0x38, 0x22, 0x35, 0x2e, 0x2a, 50, 0x24, 0x1d, 0x20
            };
            this.key = "";
            this.iniVector = "";
            this.desStrategy = CJBasic.Security.DesStrategy.DesSimple;
        }

        public DesEncryption(CJBasic.Security.DesStrategy strategy, string _key)
        {
            this.keyArray = new uint[0x10][];
            this.fst_change_tb = new int[] { 
                0x3a, 50, 0x2a, 0x22, 0x1a, 0x12, 10, 2, 60, 0x34, 0x2c, 0x24, 0x1c, 20, 12, 4,
                0x3e, 0x36, 0x2e, 0x26, 30, 0x16, 14, 6, 0x40, 0x38, 0x30, 40, 0x20, 0x18, 0x10, 8,
                0x39, 0x31, 0x29, 0x21, 0x19, 0x11, 9, 1, 0x3b, 0x33, 0x2b, 0x23, 0x1b, 0x13, 11, 3,
                0x3d, 0x35, 0x2d, 0x25, 0x1d, 0x15, 13, 5, 0x3f, 0x37, 0x2f, 0x27, 0x1f, 0x17, 15, 7
            };
            this.lst_change_tb = new int[] { 
                40, 8, 0x30, 0x10, 0x38, 0x18, 0x40, 0x20, 0x27, 7, 0x2f, 15, 0x37, 0x17, 0x3f, 0x1f,
                0x26, 6, 0x2e, 14, 0x36, 0x16, 0x3e, 30, 0x25, 5, 0x2d, 13, 0x35, 0x15, 0x3d, 0x1d,
                0x24, 4, 0x2c, 12, 0x34, 20, 60, 0x1c, 0x23, 3, 0x2b, 11, 0x33, 0x13, 0x3b, 0x1b,
                0x22, 2, 0x2a, 10, 50, 0x12, 0x3a, 0x1a, 0x21, 1, 0x29, 9, 0x31, 0x11, 0x39, 0x19
            };
            this.mid_change_tb32 = new int[] { 
                0x10, 7, 20, 0x15, 0x1d, 12, 0x1c, 0x11, 1, 15, 0x17, 0x1a, 5, 0x12, 0x1f, 10,
                2, 8, 0x18, 14, 0x20, 0x1b, 3, 9, 0x13, 13, 30, 6, 0x16, 11, 4, 0x19
            };
            this.bits_tb64 = new uint[] { 
                0x80000000, 0x40000000, 0x20000000, 0x10000000, 0x8000000, 0x4000000, 0x2000000, 0x1000000, 0x800000, 0x400000, 0x200000, 0x100000, 0x80000, 0x40000, 0x20000, 0x10000,
                0x8000, 0x4000, 0x2000, 0x1000, 0x800, 0x400, 0x200, 0x100, 0x80, 0x40, 0x20, 0x10, 8, 4, 2, 1,
                0x80000000, 0x40000000, 0x20000000, 0x10000000, 0x8000000, 0x4000000, 0x2000000, 0x1000000, 0x800000, 0x400000, 0x200000, 0x100000, 0x80000, 0x40000, 0x20000, 0x10000,
                0x8000, 0x4000, 0x2000, 0x1000, 0x800, 0x400, 0x200, 0x100, 0x80, 0x40, 0x20, 0x10, 8, 4, 2, 1
            };
            this.expt_tb = new int[] { 
                0x20, 1, 2, 3, 4, 5, 4, 5, 6, 7, 8, 9, 8, 9, 10, 11,
                12, 13, 12, 13, 14, 15, 0x10, 0x11, 0x10, 0x11, 0x12, 0x13, 20, 0x15, 20, 0x15,
                0x16, 0x17, 0x18, 0x19, 0x18, 0x19, 0x1a, 0x1b, 0x1c, 0x1d, 0x1c, 0x1d, 30, 0x1f, 0x20, 1
            };
            this.SP = new int[,] { { 
                14, 0, 4, 15, 13, 7, 1, 4, 2, 14, 15, 2, 11, 13, 8, 1,
                3, 10, 10, 6, 6, 12, 12, 11, 5, 9, 9, 5, 0, 3, 7, 8,
                4, 15, 1, 12, 14, 8, 8, 2, 13, 4, 6, 9, 2, 1, 11, 7,
                15, 5, 12, 11, 9, 3, 7, 14, 3, 10, 10, 0, 5, 6, 0, 13
            }, { 
                15, 3, 1, 13, 8, 4, 14, 7, 6, 15, 11, 2, 3, 8, 4, 15,
                9, 12, 7, 0, 2, 1, 13, 10, 12, 6, 0, 9, 5, 11, 10, 5,
                0, 13, 14, 8, 7, 10, 11, 1, 10, 3, 4, 15, 13, 4, 1, 2,
                5, 11, 8, 6, 12, 7, 6, 12, 9, 0, 3, 5, 2, 14, 15, 9
            }, { 
                10, 13, 0, 7, 9, 0, 14, 9, 6, 3, 3, 4, 15, 6, 5, 10,
                1, 2, 13, 8, 12, 5, 7, 14, 11, 12, 4, 11, 2, 15, 8, 1,
                13, 1, 6, 10, 4, 13, 9, 0, 8, 6, 15, 9, 3, 8, 0, 7,
                11, 4, 1, 15, 2, 14, 12, 3, 5, 11, 10, 5, 14, 2, 7, 12
            }, { 
                7, 13, 13, 8, 14, 11, 3, 5, 0, 6, 6, 15, 9, 0, 10, 3,
                1, 4, 2, 7, 8, 2, 5, 12, 11, 1, 12, 10, 4, 14, 15, 9,
                10, 3, 6, 15, 9, 0, 0, 6, 12, 10, 11, 10, 7, 13, 13, 8,
                15, 9, 1, 4, 3, 5, 14, 11, 5, 12, 2, 7, 8, 2, 4, 14
            }, { 
                2, 14, 12, 11, 4, 2, 1, 12, 7, 4, 10, 7, 11, 13, 6, 1,
                8, 5, 5, 0, 3, 15, 15, 10, 13, 3, 0, 9, 14, 8, 9, 6,
                4, 11, 2, 8, 1, 12, 11, 7, 10, 1, 13, 14, 7, 2, 8, 13,
                15, 6, 9, 15, 12, 0, 5, 9, 6, 10, 3, 4, 0, 5, 14, 3
            }, { 
                12, 10, 1, 15, 10, 4, 15, 2, 9, 7, 2, 12, 6, 9, 8, 5,
                0, 6, 13, 1, 3, 13, 4, 14, 14, 0, 7, 11, 5, 3, 11, 8,
                9, 4, 14, 3, 15, 2, 5, 12, 2, 9, 8, 5, 12, 15, 3, 10,
                7, 11, 0, 14, 4, 1, 10, 7, 1, 6, 13, 0, 11, 8, 6, 13
            }, { 
                4, 13, 11, 0, 2, 11, 14, 7, 15, 4, 0, 9, 8, 1, 13, 10,
                3, 14, 12, 3, 9, 5, 7, 12, 5, 2, 10, 15, 6, 8, 1, 6,
                1, 6, 4, 11, 11, 13, 13, 8, 12, 1, 3, 4, 7, 10, 14, 7,
                10, 9, 15, 5, 6, 0, 8, 15, 0, 14, 5, 2, 9, 3, 2, 12
            }, { 
                13, 1, 2, 15, 8, 13, 4, 8, 6, 10, 15, 3, 11, 7, 1, 4,
                10, 12, 9, 5, 3, 6, 14, 11, 5, 0, 0, 14, 12, 9, 7, 2,
                7, 2, 11, 1, 4, 14, 1, 7, 9, 4, 12, 10, 14, 8, 2, 13,
                0, 15, 6, 12, 10, 9, 13, 0, 15, 3, 3, 5, 5, 6, 8, 11
            } };
            this.keyleft = new int[] { 
                0x39, 0x31, 0x29, 0x21, 0x19, 0x11, 9, 1, 0x3a, 50, 0x2a, 0x22, 0x1a, 0x12, 10, 2,
                0x3b, 0x33, 0x2b, 0x23, 0x1b, 0x13, 11, 3, 60, 0x34, 0x2c, 0x24
            };
            this.keyright = new int[] { 
                0x3f, 0x37, 0x2f, 0x27, 0x1f, 0x17, 15, 7, 0x3e, 0x36, 0x2e, 0x26, 30, 0x16, 14, 6,
                0x3d, 0x35, 0x2d, 0x25, 0x1d, 0x15, 13, 5, 0x1c, 20, 12, 4
            };
            this.lefttable = new int[] { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };
            uint[] numArray = new uint[3];
            numArray[1] = 0x80000000;
            numArray[2] = 0xc0000000;
            this.leftandtab = numArray;
            this.keychoose = new int[] { 
                14, 0x11, 11, 0x18, 1, 5, 3, 0x1c, 15, 6, 0x15, 10, 0x17, 0x13, 12, 4,
                0x1a, 8, 0x10, 7, 0x1b, 20, 13, 2, 0x29, 0x34, 0x1f, 0x25, 0x2f, 0x37, 30, 40,
                0x33, 0x2d, 0x21, 0x30, 0x2c, 0x31, 0x27, 0x38, 0x22, 0x35, 0x2e, 0x2a, 50, 0x24, 0x1d, 0x20
            };
            this.key = "";
            this.iniVector = "";
            this.desStrategy = CJBasic.Security.DesStrategy.DesSimple;
            this.desStrategy = strategy;
            this.key = _key;
        }

        public DesEncryption(CJBasic.Security.DesStrategy strategy, string _key, string _iniVector)
        {
            this.keyArray = new uint[0x10][];
            this.fst_change_tb = new int[] { 
                0x3a, 50, 0x2a, 0x22, 0x1a, 0x12, 10, 2, 60, 0x34, 0x2c, 0x24, 0x1c, 20, 12, 4,
                0x3e, 0x36, 0x2e, 0x26, 30, 0x16, 14, 6, 0x40, 0x38, 0x30, 40, 0x20, 0x18, 0x10, 8,
                0x39, 0x31, 0x29, 0x21, 0x19, 0x11, 9, 1, 0x3b, 0x33, 0x2b, 0x23, 0x1b, 0x13, 11, 3,
                0x3d, 0x35, 0x2d, 0x25, 0x1d, 0x15, 13, 5, 0x3f, 0x37, 0x2f, 0x27, 0x1f, 0x17, 15, 7
            };
            this.lst_change_tb = new int[] { 
                40, 8, 0x30, 0x10, 0x38, 0x18, 0x40, 0x20, 0x27, 7, 0x2f, 15, 0x37, 0x17, 0x3f, 0x1f,
                0x26, 6, 0x2e, 14, 0x36, 0x16, 0x3e, 30, 0x25, 5, 0x2d, 13, 0x35, 0x15, 0x3d, 0x1d,
                0x24, 4, 0x2c, 12, 0x34, 20, 60, 0x1c, 0x23, 3, 0x2b, 11, 0x33, 0x13, 0x3b, 0x1b,
                0x22, 2, 0x2a, 10, 50, 0x12, 0x3a, 0x1a, 0x21, 1, 0x29, 9, 0x31, 0x11, 0x39, 0x19
            };
            this.mid_change_tb32 = new int[] { 
                0x10, 7, 20, 0x15, 0x1d, 12, 0x1c, 0x11, 1, 15, 0x17, 0x1a, 5, 0x12, 0x1f, 10,
                2, 8, 0x18, 14, 0x20, 0x1b, 3, 9, 0x13, 13, 30, 6, 0x16, 11, 4, 0x19
            };
            this.bits_tb64 = new uint[] { 
                0x80000000, 0x40000000, 0x20000000, 0x10000000, 0x8000000, 0x4000000, 0x2000000, 0x1000000, 0x800000, 0x400000, 0x200000, 0x100000, 0x80000, 0x40000, 0x20000, 0x10000,
                0x8000, 0x4000, 0x2000, 0x1000, 0x800, 0x400, 0x200, 0x100, 0x80, 0x40, 0x20, 0x10, 8, 4, 2, 1,
                0x80000000, 0x40000000, 0x20000000, 0x10000000, 0x8000000, 0x4000000, 0x2000000, 0x1000000, 0x800000, 0x400000, 0x200000, 0x100000, 0x80000, 0x40000, 0x20000, 0x10000,
                0x8000, 0x4000, 0x2000, 0x1000, 0x800, 0x400, 0x200, 0x100, 0x80, 0x40, 0x20, 0x10, 8, 4, 2, 1
            };
            this.expt_tb = new int[] { 
                0x20, 1, 2, 3, 4, 5, 4, 5, 6, 7, 8, 9, 8, 9, 10, 11,
                12, 13, 12, 13, 14, 15, 0x10, 0x11, 0x10, 0x11, 0x12, 0x13, 20, 0x15, 20, 0x15,
                0x16, 0x17, 0x18, 0x19, 0x18, 0x19, 0x1a, 0x1b, 0x1c, 0x1d, 0x1c, 0x1d, 30, 0x1f, 0x20, 1
            };
            this.SP = new int[,] { { 
                14, 0, 4, 15, 13, 7, 1, 4, 2, 14, 15, 2, 11, 13, 8, 1,
                3, 10, 10, 6, 6, 12, 12, 11, 5, 9, 9, 5, 0, 3, 7, 8,
                4, 15, 1, 12, 14, 8, 8, 2, 13, 4, 6, 9, 2, 1, 11, 7,
                15, 5, 12, 11, 9, 3, 7, 14, 3, 10, 10, 0, 5, 6, 0, 13
            }, { 
                15, 3, 1, 13, 8, 4, 14, 7, 6, 15, 11, 2, 3, 8, 4, 15,
                9, 12, 7, 0, 2, 1, 13, 10, 12, 6, 0, 9, 5, 11, 10, 5,
                0, 13, 14, 8, 7, 10, 11, 1, 10, 3, 4, 15, 13, 4, 1, 2,
                5, 11, 8, 6, 12, 7, 6, 12, 9, 0, 3, 5, 2, 14, 15, 9
            }, { 
                10, 13, 0, 7, 9, 0, 14, 9, 6, 3, 3, 4, 15, 6, 5, 10,
                1, 2, 13, 8, 12, 5, 7, 14, 11, 12, 4, 11, 2, 15, 8, 1,
                13, 1, 6, 10, 4, 13, 9, 0, 8, 6, 15, 9, 3, 8, 0, 7,
                11, 4, 1, 15, 2, 14, 12, 3, 5, 11, 10, 5, 14, 2, 7, 12
            }, { 
                7, 13, 13, 8, 14, 11, 3, 5, 0, 6, 6, 15, 9, 0, 10, 3,
                1, 4, 2, 7, 8, 2, 5, 12, 11, 1, 12, 10, 4, 14, 15, 9,
                10, 3, 6, 15, 9, 0, 0, 6, 12, 10, 11, 10, 7, 13, 13, 8,
                15, 9, 1, 4, 3, 5, 14, 11, 5, 12, 2, 7, 8, 2, 4, 14
            }, { 
                2, 14, 12, 11, 4, 2, 1, 12, 7, 4, 10, 7, 11, 13, 6, 1,
                8, 5, 5, 0, 3, 15, 15, 10, 13, 3, 0, 9, 14, 8, 9, 6,
                4, 11, 2, 8, 1, 12, 11, 7, 10, 1, 13, 14, 7, 2, 8, 13,
                15, 6, 9, 15, 12, 0, 5, 9, 6, 10, 3, 4, 0, 5, 14, 3
            }, { 
                12, 10, 1, 15, 10, 4, 15, 2, 9, 7, 2, 12, 6, 9, 8, 5,
                0, 6, 13, 1, 3, 13, 4, 14, 14, 0, 7, 11, 5, 3, 11, 8,
                9, 4, 14, 3, 15, 2, 5, 12, 2, 9, 8, 5, 12, 15, 3, 10,
                7, 11, 0, 14, 4, 1, 10, 7, 1, 6, 13, 0, 11, 8, 6, 13
            }, { 
                4, 13, 11, 0, 2, 11, 14, 7, 15, 4, 0, 9, 8, 1, 13, 10,
                3, 14, 12, 3, 9, 5, 7, 12, 5, 2, 10, 15, 6, 8, 1, 6,
                1, 6, 4, 11, 11, 13, 13, 8, 12, 1, 3, 4, 7, 10, 14, 7,
                10, 9, 15, 5, 6, 0, 8, 15, 0, 14, 5, 2, 9, 3, 2, 12
            }, { 
                13, 1, 2, 15, 8, 13, 4, 8, 6, 10, 15, 3, 11, 7, 1, 4,
                10, 12, 9, 5, 3, 6, 14, 11, 5, 0, 0, 14, 12, 9, 7, 2,
                7, 2, 11, 1, 4, 14, 1, 7, 9, 4, 12, 10, 14, 8, 2, 13,
                0, 15, 6, 12, 10, 9, 13, 0, 15, 3, 3, 5, 5, 6, 8, 11
            } };
            this.keyleft = new int[] { 
                0x39, 0x31, 0x29, 0x21, 0x19, 0x11, 9, 1, 0x3a, 50, 0x2a, 0x22, 0x1a, 0x12, 10, 2,
                0x3b, 0x33, 0x2b, 0x23, 0x1b, 0x13, 11, 3, 60, 0x34, 0x2c, 0x24
            };
            this.keyright = new int[] { 
                0x3f, 0x37, 0x2f, 0x27, 0x1f, 0x17, 15, 7, 0x3e, 0x36, 0x2e, 0x26, 30, 0x16, 14, 6,
                0x3d, 0x35, 0x2d, 0x25, 0x1d, 0x15, 13, 5, 0x1c, 20, 12, 4
            };
            this.lefttable = new int[] { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };
            uint[] numArray = new uint[3];
            numArray[1] = 0x80000000;
            numArray[2] = 0xc0000000;
            this.leftandtab = numArray;
            this.keychoose = new int[] { 
                14, 0x11, 11, 0x18, 1, 5, 3, 0x1c, 15, 6, 0x15, 10, 0x17, 0x13, 12, 4,
                0x1a, 8, 0x10, 7, 0x1b, 20, 13, 2, 0x29, 0x34, 0x1f, 0x25, 0x2f, 0x37, 30, 40,
                0x33, 0x2d, 0x21, 0x30, 0x2c, 0x31, 0x27, 0x38, 0x22, 0x35, 0x2e, 0x2a, 50, 0x24, 0x1d, 0x20
            };
            this.key = "";
            this.iniVector = "";
            this.desStrategy = CJBasic.Security.DesStrategy.DesSimple;
            this.desStrategy = strategy;
            this.key = _key;
            this.iniVector = _iniVector;
        }

        private uint[] change_data(uint[] olddata, int[] change_tb)
        {
            uint[] numArray = new uint[2];
            for (int i = 0; i < 0x40; i++)
            {
                if (i < 0x20)
                {
                    if (change_tb[i] > 0x20)
                    {
                        if ((olddata[1] & this.bits_tb64[change_tb[i] - 1]) != 0)
                        {
                            numArray[0] |= this.bits_tb64[i];
                        }
                    }
                    else if ((olddata[0] & this.bits_tb64[change_tb[i] - 1]) != 0)
                    {
                        numArray[0] |= this.bits_tb64[i];
                    }
                }
                else if (change_tb[i] > 0x20)
                {
                    if ((olddata[1] & this.bits_tb64[change_tb[i] - 1]) != 0)
                    {
                        numArray[1] |= this.bits_tb64[i];
                    }
                }
                else if ((olddata[0] & this.bits_tb64[change_tb[i] - 1]) != 0)
                {
                    numArray[1] |= this.bits_tb64[i];
                }
            }
            return numArray;
        }

        public byte[] Decrypt(byte[] encrypted)
        {
            int count = BitConverter.ToInt32(encrypted, 0);
            byte[] dst = new byte[encrypted.Length - 4];
            Buffer.BlockCopy(encrypted, 4, dst, 0, dst.Length);
            byte[] src = null;
            if (this.desStrategy == CJBasic.Security.DesStrategy.DesSimple)
            {
                src = this.Des(dst, this.key, false);
            }
            else if (this.desStrategy == CJBasic.Security.DesStrategy.Des3)
            {
                src = this.Des3(dst, this.key, false);
            }
            else if (this.desStrategy == CJBasic.Security.DesStrategy.DesCBC)
            {
                src = this.DesCBC(dst, this.key, this.iniVector, false);
            }
            else if (this.desStrategy == CJBasic.Security.DesStrategy.DesTwoKeys)
            {
                src = this.DesTwoKeys(dst, this.key, this.iniVector, false);
            }
            byte[] buffer3 = new byte[count];
            Buffer.BlockCopy(src, 0, buffer3, 0, count);
            return buffer3;
        }

        public static byte[] Decrypt(byte[] encrypted, string key)
        {
            DesEncryption encryption = new DesEncryption(CJBasic.Security.DesStrategy.Des3, key);
            return encryption.Decrypt(encrypted);
        }

        public static string DecryptString(string encrypted, string key)
        {
            byte[] bytes = Decrypt(Encoding.UTF8.GetBytes(encrypted), key);
            return Encoding.UTF8.GetString(bytes);
        }

        private byte[] Des(byte[] input_data, string key, bool encrypt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(key);
            uint[] numArray = new uint[] { BitConverter.ToUInt32(bytes, 0), BitConverter.ToUInt32(bytes, 4) };
            return this.Des(input_data, numArray, encrypt);
        }

        private byte[] Des(byte[] data, uint[] key, bool encrypt)
        {
            int num;
            uint[] numArray = new uint[data.Length / 4];
            uint[] numArray2 = new uint[data.Length / 4];
            byte[] buffer = new byte[data.Length];
            for (num = 0; num < data.Length; num += 4)
            {
                numArray[num / 4] |= data[num];
                numArray[num / 4] = numArray[num / 4] << 8;
                numArray[num / 4] |= data[num + 1];
                numArray[num / 4] = numArray[num / 4] << 8;
                numArray[num / 4] |= data[num + 2];
                numArray[num / 4] = numArray[num / 4] << 8;
                numArray[num / 4] |= data[num + 3];
            }
            numArray2 = this.Des(numArray, key, encrypt);
            for (num = 0; num < numArray2.Length; num++)
            {
                buffer[(4 * num) + 3] = (byte) (buffer[(4 * num) + 3] | ((byte) (numArray2[num] & 0xff)));
                numArray2[num] = numArray2[num] >> 8;
                buffer[(4 * num) + 2] = (byte) (buffer[(4 * num) + 2] | ((byte) (numArray2[num] & 0xff)));
                numArray2[num] = numArray2[num] >> 8;
                buffer[(4 * num) + 1] = (byte) (buffer[(4 * num) + 1] | ((byte) (numArray2[num] & 0xff)));
                numArray2[num] = numArray2[num] >> 8;
                buffer[4 * num] = (byte) (buffer[4 * num] | ((byte) (numArray2[num] & 0xff)));
            }
            return buffer;
        }

        private uint[] Des(uint[] data, uint[] key, bool encrypt)
        {
            uint[] numArray = new uint[data.Length];
            uint[] numArray2 = new uint[2];
            uint[] numArray3 = new uint[2];
            this.DesCreateKeys(key);
            for (int i = 0; i < data.Length; i += 2)
            {
                numArray2[0] = data[i];
                numArray2[1] = data[i + 1];
                numArray3 = this.handle_data(numArray2, encrypt);
                numArray[i] = numArray3[0];
                numArray[i + 1] = numArray3[1];
            }
            return numArray;
        }

        private uint[] Des(uint[] data, uint[] key, uint[] iv, bool encrypt)
        {
            uint[] numArray = new uint[data.Length];
            uint[] numArray2 = new uint[2];
            uint[] numArray3 = new uint[2];
            uint num = 0;
            uint num2 = 0;
            this.DesCreateKeys(key);
            for (int i = 0; i < data.Length; i += 2)
            {
                numArray2[0] = data[i];
                numArray2[1] = data[i + 1];
                if (encrypt)
                {
                    numArray2[0] ^= iv[0];
                    numArray2[1] ^= iv[1];
                }
                else
                {
                    num = iv[0];
                    num2 = iv[1];
                    iv[0] = numArray2[0];
                    iv[1] = numArray2[1];
                }
                numArray3 = this.handle_data(numArray2, encrypt);
                if (encrypt)
                {
                    iv[0] = numArray3[0];
                    iv[1] = numArray3[1];
                }
                else
                {
                    numArray3[0] ^= num;
                    numArray3[1] ^= num2;
                }
                numArray[i] = numArray3[0];
                numArray[i + 1] = numArray3[1];
            }
            return numArray;
        }

        private byte[] Des3(byte[] input_data, string key, bool encrypt)
        {
            for (int i = 0; i < 3; i++)
            {
                input_data = this.Des(input_data, key, encrypt);
            }
            return input_data;
        }

        private byte[] DesCBC(byte[] input_data, string key_str, string iv, bool encrypt)
        {
            int num;
            byte[] bytes = Encoding.UTF8.GetBytes(key_str);
            uint[] key = new uint[] { BitConverter.ToUInt32(bytes, 0), BitConverter.ToUInt32(bytes, 4) };
            bytes = Encoding.UTF8.GetBytes(iv);
            uint[] numArray2 = new uint[] { BitConverter.ToUInt32(bytes, 0), BitConverter.ToUInt32(bytes, 4) };
            uint[] data = new uint[input_data.Length / 4];
            uint[] numArray4 = new uint[input_data.Length / 4];
            byte[] buffer2 = new byte[input_data.Length];
            for (num = 0; num < input_data.Length; num += 4)
            {
                data[num / 4] |= input_data[num];
                data[num / 4] = data[num / 4] << 8;
                data[num / 4] |= input_data[num + 1];
                data[num / 4] = data[num / 4] << 8;
                data[num / 4] |= input_data[num + 2];
                data[num / 4] = data[num / 4] << 8;
                data[num / 4] |= input_data[num + 3];
            }
            numArray4 = this.Des(data, key, numArray2, encrypt);
            for (num = 0; num < numArray4.Length; num++)
            {
                buffer2[(4 * num) + 3] = (byte) (buffer2[(4 * num) + 3] | ((byte) (numArray4[num] & 0xff)));
                numArray4[num] = numArray4[num] >> 8;
                buffer2[(4 * num) + 2] = (byte) (buffer2[(4 * num) + 2] | ((byte) (numArray4[num] & 0xff)));
                numArray4[num] = numArray4[num] >> 8;
                buffer2[(4 * num) + 1] = (byte) (buffer2[(4 * num) + 1] | ((byte) (numArray4[num] & 0xff)));
                numArray4[num] = numArray4[num] >> 8;
                buffer2[4 * num] = (byte) (buffer2[4 * num] | ((byte) (numArray4[num] & 0xff)));
            }
            return buffer2;
        }

        private void DesCreateKeys(uint[] key)
        {
            int num;
            uint[] numArray = new uint[2];
            for (num = 0; num < 0x1c; num++)
            {
                if (this.keyleft[num] > 0x20)
                {
                    if ((key[1] & this.bits_tb64[this.keyleft[num] - 1]) != 0)
                    {
                        numArray[0] |= this.bits_tb64[num];
                    }
                }
                else if ((key[0] & this.bits_tb64[this.keyleft[num] - 1]) != 0)
                {
                    numArray[0] |= this.bits_tb64[num];
                }
                if (this.keyright[num] > 0x20)
                {
                    if ((key[1] & this.bits_tb64[this.keyright[num] - 1]) != 0)
                    {
                        numArray[1] |= this.bits_tb64[num];
                    }
                }
                else if ((key[0] & this.bits_tb64[this.keyright[num] - 1]) != 0)
                {
                    numArray[1] |= this.bits_tb64[num];
                }
            }
            for (num = 0; num < 0x10; num++)
            {
                this.keyArray[num] = this.make_key(numArray, num);
            }
        }

        private byte[] DesTwoKeys(byte[] input_data, string key1, string key2, bool encrypt)
        {
            byte[] buffer = this.Des(input_data, key1, encrypt);
            buffer = this.Des(buffer, key2, !encrypt);
            return this.Des(buffer, key1, encrypt);
        }

        public byte[] Encrypt(byte[] origin)
        {
            int length = origin.Length;
            int num2 = ((origin.Length % 8) == 0) ? origin.Length : ((origin.Length + 8) - (origin.Length % 8));
            byte[] array = new byte[num2];
            origin.CopyTo(array, 0);
            byte[] src = null;
            if (this.desStrategy == CJBasic.Security.DesStrategy.DesSimple)
            {
                src = this.Des(array, this.key, true);
            }
            else if (this.desStrategy == CJBasic.Security.DesStrategy.Des3)
            {
                src = this.Des3(array, this.key, true);
            }
            else if (this.desStrategy == CJBasic.Security.DesStrategy.DesCBC)
            {
                src = this.DesCBC(array, this.key, this.iniVector, true);
            }
            else if (this.desStrategy == CJBasic.Security.DesStrategy.DesTwoKeys)
            {
                src = this.DesTwoKeys(array, this.key, this.iniVector, true);
            }
            byte[] dst = new byte[4 + src.Length];
            Buffer.BlockCopy(BitConverter.GetBytes(length), 0, dst, 0, 4);
            Buffer.BlockCopy(src, 0, dst, 4, src.Length);
            return dst;
        }

        public static byte[] Encrypt(byte[] origin, string key)
        {
            DesEncryption encryption = new DesEncryption(CJBasic.Security.DesStrategy.Des3, key);
            return encryption.Encrypt(origin);
        }

        public static string EncryptString(string origin, string key)
        {
            byte[] bytes = Encrypt(Encoding.UTF8.GetBytes(origin), key);
            return Encoding.UTF8.GetString(bytes);
        }

        private uint[] handle_data(uint[] data, bool encrypt)
        {
            int num;
            uint[] numArray = new uint[2];
            uint[] numArray2 = this.change_data(data, this.fst_change_tb);
            if (encrypt)
            {
                for (num = 0; num < 0x10; num++)
                {
                    this.make_data(numArray2, num);
                }
            }
            else
            {
                for (num = 15; num >= 0; num--)
                {
                    this.make_data(numArray2, num);
                }
            }
            uint num2 = numArray2[0];
            numArray2[0] = numArray2[1];
            numArray2[1] = num2;
            return this.change_data(numArray2, this.lst_change_tb);
        }

        private void make_data(uint[] data, int number)
        {
            int num;
            uint[] numArray = new uint[2];
            byte[] buffer = new byte[8];
            uint num3 = data[1];
            for (num = 0; num < 0x30; num++)
            {
                if (num < 0x18)
                {
                    if ((data[1] & this.bits_tb64[this.expt_tb[num] - 1]) != 0)
                    {
                        numArray[0] |= this.bits_tb64[num] >> 8;
                    }
                }
                else if ((data[1] & this.bits_tb64[this.expt_tb[num] - 1]) != 0)
                {
                    numArray[1] |= this.bits_tb64[num - 0x18] >> 8;
                }
            }
            for (num = 0; num < 2; num++)
            {
                numArray[num] ^= this.keyArray[number][num] & 0xfffffff;
            }
            buffer[7] = (byte) (numArray[1] & 0x3f);
            numArray[1] = numArray[1] >> 6;
            buffer[6] = (byte) (numArray[1] & 0x3f);
            numArray[1] = numArray[1] >> 6;
            buffer[5] = (byte) (numArray[1] & 0x3f);
            numArray[1] = numArray[1] >> 6;
            buffer[4] = (byte) (numArray[1] & 0x3f);
            buffer[3] = (byte) (numArray[0] & 0x3f);
            numArray[0] = numArray[0] >> 6;
            buffer[2] = (byte) (numArray[0] & 0x3f);
            numArray[0] = numArray[0] >> 6;
            buffer[1] = (byte) (numArray[0] & 0x3f);
            numArray[0] = numArray[0] >> 6;
            buffer[0] = (byte) (numArray[0] & 0x3f);
            data[1] = 0;
            num = 0;
            while (num < 7)
            {
                data[1] |= (uint) this.SP[(int) ((IntPtr) num), (int) ((IntPtr) buffer[num])];
                data[1] = data[1] << 4;
                num++;
            }
            data[1] |= (uint) this.SP[(int) ((IntPtr) num), (int) ((IntPtr) buffer[num])];
            uint num2 = 0;
            for (num = 0; num < 0x20; num++)
            {
                if ((data[1] & this.bits_tb64[this.mid_change_tb32[num] - 1]) != 0)
                {
                    num2 |= this.bits_tb64[num];
                }
            }
            data[1] = num2;
            data[1] ^= data[0];
            data[0] = num3;
        }

        private uint[] make_key(uint[] in_key, int number)
        {
            uint[] numArray = new uint[2];
            int index = this.lefttable[number];
            uint num = in_key[0] & this.leftandtab[index];
            num = num >> (0x1c - index);
            num &= 0xfffffff0;
            uint num2 = in_key[1] & this.leftandtab[index];
            num2 = num2 >> (0x1c - index);
            num2 &= 0xfffffff0;
            in_key[0] = in_key[0] << index;
            in_key[1] = in_key[1] << index;
            in_key[0] |= num;
            in_key[1] |= num2;
            for (int i = 0; i < 0x30; i++)
            {
                if (i < 0x18)
                {
                    if ((in_key[0] & this.bits_tb64[this.keychoose[i] - 1]) != 0)
                    {
                        numArray[0] |= this.bits_tb64[i];
                    }
                }
                else if ((in_key[1] & this.bits_tb64[this.keychoose[i] - 0x1d]) != 0)
                {
                    numArray[1] |= this.bits_tb64[i - 0x18];
                }
            }
            numArray[0] = numArray[0] >> 8;
            numArray[1] = numArray[1] >> 8;
            return numArray;
        }

        public CJBasic.Security.DesStrategy DesStrategy
        {
            get
            {
                return this.desStrategy;
            }
            set
            {
                this.desStrategy = value;
            }
        }

        public string IniVector
        {
            get
            {
                return this.iniVector;
            }
            set
            {
                this.iniVector = value;
            }
        }

        public string Key
        {
            get
            {
                return this.key;
            }
            set
            {
                this.key = value;
            }
        }
    }
}

