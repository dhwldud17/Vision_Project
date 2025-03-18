using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using JidamVision.Core;
namespace JidamVision.Algorithm
{
    public class FmInspAlgorithm : InspAlgorithm
    {
        public Size ExtSize { get; set; } = new Size(100, 100);

        public int SizeX { get; set; } = 10;   // 최소 면적
        public int SizeY { get; set; } = 10; // 최대 면적

        public int GV { get; set; } =50;
        public FmInspAlgorithm()
        {
            InspectType = InspectType.InspFm;
        }

        public override bool DoInspect()
        {
            // 실제 검사 로직 구현
            
            return (true);
        }

    }
}
