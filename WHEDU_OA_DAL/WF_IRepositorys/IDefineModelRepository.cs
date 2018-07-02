using WHEDU_OA_MODELS;


namespace WHEDU_OA_DAL
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
