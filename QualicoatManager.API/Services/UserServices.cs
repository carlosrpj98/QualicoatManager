using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using QualicoatManager.API.Query;
using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Interfaces;
using QualicoatManager.Domain.Specifications;
using static System.Net.WebRequestMethods;

namespace QualicoatManager.API.Services
{
    public class UserServices
    {
        //private readonly IGenericRepository<Formulation> _formulationsRepo;
        //private readonly IGenericRepository<RawMaterial> _rawMaterialsRepo;
        //private readonly IGenericRepository<Assessment> _assessmentRepo;
        //private readonly IGenericRepository<AssessmentsGroup> _assessmentsGroupRepo;
        //private readonly IGenericRepository<FormulationsFolder> _formulationsFolderRepo;
        //private readonly IGenericRepository<BaseUser> _userRepo;
        //private readonly BaseUser _user;

        //public UserServices(IGenericRepository<Formulation> formulationsRepo,
        //                    IGenericRepository<RawMaterial> rawMaterialsRepo,
        //                    IGenericRepository<Assessment> assesmentRepo,
        //                    IGenericRepository<AssessmentsGroup> assesmentsGroupRepo,
        //                    IGenericRepository<FormulationsFolder> formulationsFolderRepo,
        //                    IGenericRepository<BaseUser> userRepo,
        //                    BaseUser user)
        //{
        //    _formulationsRepo = formulationsRepo;
        //    _rawMaterialsRepo = rawMaterialsRepo;
        //    _assessmentRepo = assesmentRepo;
        //    _assessmentsGroupRepo = assesmentsGroupRepo;
        //    _formulationsFolderRepo = formulationsFolderRepo;
        //    _userRepo = userRepo;
        //    _user = user;
        //}

        //private readonly GraphQLHttpClient _httpClient;
        //public UserServices(string endpoint = "http://localhost:5230/qualicoat/")
        //{
        //    _httpClient = new GraphQLHttpClient(endpoint, new NewtonsoftJsonSerializer());
        //}

        //Admin only
        //public async Task<bool> CreateUser(List<UserRole> roles, string username, string password, string confirmPassword)
        //{
        //HasRole(Roles.Admin);

        //bool success = false;

        //if (password == confirmPassword)
        //{
        //    IPasswordHasher hasher = new PasswordHasher();

        //    string hashedPassword = hasher.HashPassword(password);

        //    //Check user exist
        //    var userExist = await _userRepo.SearchByNameAsync(username);
        //    if (userExist != null)
        //    {
        //        throw new Exception("Username already exists!");
        //    }

        //    BaseUser user = new BaseUser()
        //    {
        //        Name = username,
        //        Password = hashedPassword,
        //        UserRoles = roles
        //    };

        //    await _userRepo.CreateItemAsync(user);
        //    success = true;
        //}

        //return success;
        //}


        //Formulations services
        //public async Task GetFormulationsList()
        //{
        //    var request = new GraphQLRequest
        //    {
        //        Query = @"
        //            allFormulations{
        //                    formulations{
        //                    name
        //                    }}",
        //    };

        //    var graphQLResponse = await _httpClient.SendQueryAsync<dynamic>(request);

        //}

        //public void GetFormulation(int id)
        //{
        //    var spec = new FormulationWithRawMaterialsAndAssesments(id);
        //    _formulationsRepo.GetEntityWithSpecAsync(spec);
        //}

        //public void GetFormulationsByName(string name)
        //{
        //    _formulationsRepo.SearchByNameAsync(name);
        //}

        //public void CreateFormulation(Formulation formulation)
        //{
        //    HasRole(Roles.RegularUser);

        //    _formulationsRepo.CreateItemAsync(formulation);
        //}

        //public void EditFormulation(Formulation formulation, int id)
        //{
        //    HasRole(Roles.RegularUser);

        //    _formulationsRepo.UpdateItemAsync(formulation, id);
        //}

        //public void DeleteFormulation(int id)
        //{
        //    HasRole(Roles.RegularUser);

        //    _formulationsRepo.DeleteItemAsync(id);
        //}

        //Raw Materials services
        public async Task GetRawMaterialsList()
        {
            var client = new GraphQLHttpClient(new GraphQLHttpClientOptions
            {
                EndPoint = new Uri("http://localhost:5230/qualicoat/"),

            }, new NewtonsoftJsonSerializer());


            var request = new GraphQLRequest
            {
                Query = @"{
                          rawMaterialQuery {
                            rawMaterials {
                              id
                              name
                              description
                              category
                            }
                          }
                        }"
            };
            

            var graphQLResponse = await client.SendQueryAsync<dynamic>(request);

            var rawMaterials = graphQLResponse.Data.rawMaterialQuery.rawMaterials;          
        }


        //public void GetRawMaterialsByName(string name)
        //{
        //    _rawMaterialsRepo.SearchByNameAsync(name);
        //}

        //public void GetRawMaterial(int id)
        //{
        //    _rawMaterialsRepo.GetByIdAsync(id);
        //}

        //public void CreateRawMaterial(RawMaterial rawMaterial)
        //{
        //    HasRole(Roles.RegularUser);

        //    _rawMaterialsRepo.CreateItemAsync(rawMaterial);
        //}

        //public void EditRawMaterial(RawMaterial rawMaterial, int id)
        //{
        //    HasRole(Roles.RegularUser);

        //    _rawMaterialsRepo.UpdateItemAsync(rawMaterial, id);
        //}

        //public void DeleteRawMaterial(int id)
        //{
        //    HasRole(Roles.RegularUser);

        //    _rawMaterialsRepo.DeleteItemAsync(id);
        //}

        ////Formulation Folders services
        //public void GetFormulationFoldersList()
        //{
        //    _formulationsFolderRepo.GetAllAsync();
        //}

        //public void GetFormulationFolder(int id)
        //{
        //    _formulationsFolderRepo.GetByIdAsync(id);
        //}

        //public void CreateFormulationsFolder(FormulationsFolder formulationsFolder)
        //{
        //    HasRole(Roles.RegularUser);

        //    _formulationsFolderRepo.CreateItemAsync(formulationsFolder);
        //}

        //public void UpdateFormulationsFolder(FormulationsFolder formulationsFolder, int id)
        //{
        //    HasRole(Roles.RegularUser);

        //    _formulationsFolderRepo.UpdateItemAsync(formulationsFolder, id);
        //}

        //public void DeleteFormulationsFolder(int id)
        //{
        //    HasRole(Roles.RegularUser);

        //    _formulationsFolderRepo.DeleteItemAsync(id);
        //}

        ////Assessments Group services
        //public void GetAssessmentsGroupsList()
        //{
        //    _assessmentsGroupRepo.GetAllAsync();
        //}

        //public void GetAssessmentGroup(int id)
        //{
        //    _assessmentsGroupRepo.GetByIdAsync(id);
        //}

        //public void CreateAssesmentsGroup(AssessmentsGroup assesmentsGroup)
        //{
        //    HasRole(Roles.RegularUser);

        //    _assessmentsGroupRepo.CreateItemAsync(assesmentsGroup);
        //}

        //public void EditAssesmentsGroup(AssessmentsGroup assessmentsGroup, int id)
        //{
        //    HasRole(Roles.RegularUser);

        //    _assessmentsGroupRepo.UpdateItemAsync(assessmentsGroup, id);
        //}

        //public void DeleteAssesmentGroup(int id)
        //{
        //    HasRole(Roles.RegularUser);

        //    _assessmentRepo.DeleteItemAsync(id);
        //}

        ////Assessments services

        //public void GetAssessmentsList()
        //{
        //    _assessmentRepo.GetAllAsync();
        //}

        //public void GetAssessment(int id)
        //{
        //    _assessmentRepo.GetByIdAsync(id);
        //}

        //public void CreateAssesments(Assessment assessment)
        //{
        //    HasRole(Roles.RegularUser);

        //    _assessmentRepo.CreateItemAsync(assessment);
        //}

        //public void EditAssesments(Assessment assessment, int id)
        //{
        //    HasRole(Roles.RegularUser);

        //    _assessmentRepo.UpdateItemAsync(assessment, id);
        //}

        //public void DeleteAssesment(int id)
        //{
        //    HasRole(Roles.RegularUser);

        //    _assessmentRepo.DeleteItemAsync(id);
        //}


        //public void HasRole(Roles role)
        //{
        //    if (!_user.UserRoles.Any(userRole => userRole.Role == role))
        //    {
        //        throw new Exception($"This function is allowed only for {role} users");
        //    }

        //}

    }
}
