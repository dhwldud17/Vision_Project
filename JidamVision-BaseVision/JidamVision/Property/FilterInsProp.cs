using OpenCvSharp.Extensions;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JidamVision.Core;

namespace JidamVision.Property
{
 
    public partial class FilterInsProp : UserControl
    {
        public event EventHandler<FilterSelectedEventArgs> FilterSelected;
        private String _selected_effect;
        private int _selected_effect2 = -1;
        private string op_values = "0 0 0";


        
        public FilterInsProp()
        {
            InitializeComponent();
        }

        private void select_effect_SelectedIndexChanged(object sender, EventArgs e)
        {
            //만약 이 콤보박스를 눌러서 적용할 효과를 선택하면 각 효과에 따라 밑에 뜨는 콤보박스목록이 달라야함.
            _selected_effect = Convert.ToString(select_effect.SelectedItem); //선택한 효과 적용
            select_effect2.Items.Clear(); // 이전 항목들을 지우고 새 항목을 추가
                                          // 선택한 필터 유형에 맞는 옵션을 가져와 추가
            List<string> filters =GetFilters(_selected_effect);
            if (filters.Count > 0)
            {
                select_effect2.Items.AddRange(filters.ToArray());
                select_effect2.Show();
            }
            else
            {
                select_effect2.Hide();
            }


        }


        // 필터 목록을 Dictionary로 관리
        private static readonly Dictionary<string, List<string>> _filterMap = new Dictionary<string, List<string>>()
    {
        { "연산", new List<string> { "더하기", "빼기", "곱하기", "나누기", "최대값 비교", "최소값 비교", "절대값 계산", "절대값 차이 계산" } },
        { "비트연산(Bitwise)", new List<string> { "AND 연산", "OR 연산", "XOR 연산", "NOT 연산" } },
        { "블러링", new List<string> { "블러 필터", "박스 필터", "미디안 블러", "가우시안 블러", "양방향 필터" } },
        { "Edge", new List<string> { "Sobel 필터", "Scharr 필터", "Laplacian 필터", "Canny 엣지" } },
       
    };
        // 특정 필터 목록 가져오기
        public static List<string> GetFilters(string filterType)
        {
            return _filterMap.ContainsKey(filterType) ? _filterMap[filterType] : new List<string>();
        }


        private void apply_Click(object sender, EventArgs e)
        {
            if (_selected_effect == null || _selected_effect2 == -1) // 두 번째 효과가 선택되지 않은 경우
            {
                MessageBox.Show("효과를 선택해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FilterSelected?.Invoke(this,new FilterSelectedEventArgs(_selected_effect,_selected_effect2));
        }

        private void select_effect2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selected_effect2 = Convert.ToInt32(select_effect2.SelectedIndex);// 선택된 인덱스를 저장
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
    }

    public class FilterSelectedEventArgs : EventArgs
    {
        public string FilterSelected1 { get; }  //적용할 필터효과
        public int FilterSelected2 { get; }  //필터 옵션들 중 선택한것

        public FilterSelectedEventArgs(string filterSelected, int filterSelected2) 
        {
            FilterSelected1 = filterSelected;
            FilterSelected2 = filterSelected2;

        }
    }



}
