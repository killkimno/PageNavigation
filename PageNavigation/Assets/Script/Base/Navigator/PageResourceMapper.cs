using Assets.Script.Base.Page;
using Assets.Script.Page;
using Assets.Script.Page.SamplePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Base.Navigator
{
    public class PageResourceMapper
    {
        private Dictionary<PageType, Type> _mapper = new();

        public PageResourceMapper()
        {
            Initialize();
        }

        public Type GetPageType(PageType pageType)
        {
            return _mapper[pageType];
        }

        private void Initialize()
        {
            //TODO : 코드젠을 이용해서 연결해 줘야한다
            //이 샘플에서는 수동으로 대입한다
            _mapper.Add(PageType.Sample, typeof(SamplePagePresenter));
            
        }
    }
}
