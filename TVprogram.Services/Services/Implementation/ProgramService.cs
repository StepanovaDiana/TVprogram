using AutoMapper;
using TVprogram.Entity.Models;
using TVprogram.Repository;
using TVprogram.Services.Abstract;
using TVprogram.Services.Models;

namespace TVprogram.Services.Implementation;

public class ProgramService : IProgramService
{
    private readonly IRepository<Programa> programRepository;
    private readonly IMapper mapper;
    public ProgramService(IRepository<Programa> programRepository, IMapper mapper)
    {
        this.programRepository = programRepository;
        this.mapper = mapper;
    }

    public void DeleteProgram(Guid id)
    {
        var programToDelete = programRepository.GetById(id);
        if (programToDelete == null)
        {
            throw new Exception("Program not found");
        }
        programRepository.Delete(programToDelete);
    }

    public ProgramModel GetProgram(Guid id)
    {
        var program = programRepository.GetById(id);
        return mapper.Map<ProgramModel>(program);
    }

    public PageModel<ProgramPreviewModel> GetPrograms(int limit = 20, int offset = 0)
    {
        var programs =programRepository.GetAll();
        int totalCount = programs.Count();
        var chunk = programs.OrderBy(x => x.ChannelId).Skip(offset).Take(limit);
        

        return new PageModel<ProgramPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<ProgramPreviewModel>>(programs),
            TotalCount = totalCount
        };
    }

    public ProgramModel UpdateProgram(Guid id, UpdateProgramModel program)
    {
        var existingProgram = programRepository.GetById(id);
        if (existingProgram == null)
        {
            throw new Exception("Program not found");
        }
        existingProgram.Name=program.Name;
        existingProgram.Duration=program.Duration;
        existingProgram.Time=program.Time;
        existingProgram = programRepository.Save(existingProgram);
        return mapper.Map<ProgramModel>(existingProgram);
    }
    ProgramModel IProgramService.CreateProgram(CreateProgramModel programModel)
    {
      var program= mapper.Map<Entity.Models.Programa>(programModel);
       return mapper.Map<ProgramModel>(programRepository.Save(program));
    }
}
