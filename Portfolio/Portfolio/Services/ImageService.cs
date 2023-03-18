using Portfolio.Models;

namespace Portfolio.Services;

public class ImageService
{
    private readonly PathService pathService;

    public ImageService(PathService pathService)
    {
        this.pathService = pathService;
    }

    public async Task<Image> SkillUploadAsync(Image image)
    {
        var uploadsPath = pathService.GetSkillsUploadPath();

        var imageFile = image.File;
        var imageFileName = GetRandomFileName(imageFile.FileName);
        var imageUploadPath = Path.Combine(uploadsPath, imageFileName);

        using (var fs = new FileStream(imageUploadPath, FileMode.Create))
        {
            await imageFile.CopyToAsync(fs);
        }

        image.Name = imageFile.FileName;
        image.Path = pathService.GetSkillsUploadPath(imageFileName, withWebRootPath: false);

        return image;
    }

    public void SkillDeleteUploadedFile(Image? image)
    {
        if (image == null)
            return;

        var imagePath = pathService.GetSkillsUploadPath(Path.GetFileName(image.Path));

        if (File.Exists(imagePath))
            File.Delete(imagePath);
    }

    public async Task<Image> ProjectUploadAsync(Image image)
    {
        var uploadsPath = pathService.GetProjectsUploadPath();

        var imageFile = image.File;
        var imageFileName = GetRandomFileName(imageFile.FileName);
        var imageUploadPath = Path.Combine(uploadsPath, imageFileName);

        using (var fs = new FileStream(imageUploadPath, FileMode.Create))
        {
            await imageFile.CopyToAsync(fs);
        }

        image.Name = imageFile.FileName;
        image.Path = pathService.GetProjectsUploadPath(imageFileName, withWebRootPath: false);

        return image;
    }

    public void ProjectDeleteUploadedFile(Image? image)
    {
        if (image == null)
            return;

        var imagePath = pathService.GetProjectsUploadPath(Path.GetFileName(image.Path));

        if (File.Exists(imagePath))
            File.Delete(imagePath);
    }

    public async Task<Image> SchoolUploadAsync(Image image)
    {
        var uploadsPath = pathService.GetSchoolsUploadPath();

        var imageFile = image.File;
        var imageFileName = GetRandomFileName(imageFile.FileName);
        var imageUploadPath = Path.Combine(uploadsPath, imageFileName);

        using (var fs = new FileStream(imageUploadPath, FileMode.Create))
        {
            await imageFile.CopyToAsync(fs);
        }

        image.Name = imageFile.FileName;
        image.Path = pathService.GetSchoolsUploadPath(imageFileName, withWebRootPath: false);

        return image;
    }

    public void SchoolDeleteUploadedFile(Image? image)
    {
        if (image == null)
            return;

        var imagePath = pathService.GetSchoolsUploadPath(Path.GetFileName(image.Path));

        if (File.Exists(imagePath))
            File.Delete(imagePath);
    }

    private string GetRandomFileName(string filename)
    {
        return Guid.NewGuid() + Path.GetExtension(filename);
    }
}