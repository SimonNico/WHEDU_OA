using WHEDU_WF_ENGINE.Models;


namespace  WHEDU_WF_ENGINE.Interfaces
{
    public interface IDefineModelRepository
    {
         DefineModels GetDefineModelByID(string m_id);
        //DefineModels GetDefineModelByIDandVNO(string m_id, string vison_no);

        DefineModels GetLastDefineModelByName(string m_name);

        int AbateDefineModel(DefineModels model);

        int AddDefineModel(DefineModels dmodel); 

        int AbateDefineModelByID(string m_id);

    }
}
