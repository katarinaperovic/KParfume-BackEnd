namespace KParfume.API.DTOs;

public class UserDto
{
    public long Id { get; set; }
    public string kor_email { get;  set; }
    public string kor_lozinka { get;  set; }
    public UserRoleDto kor_uloga { get;  set; }
    public string kor_ime { get;  set; }
    public string kor_prezime { get;  set; }
    public string kor_adresa { get;  set; }
    public string kor_grad { get;  set; }
    public int kor_pos_br { get;  set; }
    public string kor_drzava { get;  set; }
    public string kor_tel { get;  set; }
    public long? kor_fab_id { get;  set; }
    public string? kor_ime_kompanije { get;  set; }
}

public enum UserRoleDto
{
    ADMINISTRATOR,
    MENADZER,
    RADNIK,
    KUPAC
}