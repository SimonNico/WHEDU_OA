using WWHEDU_WF_ENGINE.Models;


namespace WWHEDU_WF_ENGINE.Interfaces
{
    public  interface IWF_Define
    {
        int DefineModelAndNodes(DefineBindingModel dmodel,string userid);
    }
}
