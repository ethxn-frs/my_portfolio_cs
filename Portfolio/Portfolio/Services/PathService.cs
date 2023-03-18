using Portfolio.Options;

namespace Portfolio.Services
{
    public class PathService
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public PathService(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public string GetSkillsUploadPath(string? filename = null, bool withWebRootPath = true)
        {
            var pathOptions = new SkillsPathOptions();

            _configuration.GetSection(SkillsPathOptions.Path).Bind(pathOptions);

            var uploadsPath = pathOptions.SkillsImages;

            if (null != filename)
                uploadsPath = Path.Combine(uploadsPath, filename);

            return withWebRootPath ? Path.Combine(_environment.WebRootPath, uploadsPath) : uploadsPath;
        }

        public string GetSchoolsUploadPath(string? filename = null, bool withWebRootPath = true)
        {
            var pathOptions = new SchoolsPathOptions();

            _configuration.GetSection(SchoolsPathOptions.Path).Bind(pathOptions);

            var uploadsPath = pathOptions.SchoolsImages;

            if (null != filename)
                uploadsPath = Path.Combine(uploadsPath, filename);

            return withWebRootPath ? Path.Combine(_environment.WebRootPath, uploadsPath) : uploadsPath;
        }
        public string GetProjectsUploadPath(string? filename = null, bool withWebRootPath = true)
        {
            var pathOptions = new ProjectsPathOptions();

            _configuration.GetSection(ProjectsPathOptions.Path).Bind(pathOptions);

            var uploadsPath = pathOptions.ProjectsImages;

            if (null != filename)
                uploadsPath = Path.Combine(uploadsPath, filename);

            return withWebRootPath ? Path.Combine(_environment.WebRootPath, uploadsPath) : uploadsPath;
        }
    }
}
