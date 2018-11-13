package heimdall;

public class Usuario {

	private int codUsuario;
	private String nomeCompleto;
	private String email;
	private String cargo;
	private String senha;
	private boolean ativo = true;
	private Computador computador;

	public Usuario(int codUsuario, String nomeCompleto, String email, String cargo, String senha) {
		this.codUsuario = codUsuario;
		this.nomeCompleto = nomeCompleto;
		this.email = email;
		this.cargo = cargo;
		this.senha = senha;
	}

	public Usuario(String email, String senha) {
		this.email = email;
		this.senha = senha;
	}

	public Computador getComputador() {
		return computador;
	}

	public void setComputador(Computador computador) {
		this.computador = computador;
	}

	public int getCodUsuario() {
		return codUsuario;
	}

	public void setCodUsuario(int codUsuario) {
		this.codUsuario = codUsuario;
	}

	public String getNomeCompleto() {
		return nomeCompleto;
	}

	public void setNomeCompleto(String nomeCompleto) {
		this.nomeCompleto = nomeCompleto;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getCargo() {
		return cargo;
	}

	public void setCargo(String cargo) {
		this.cargo = cargo;
	}

	public String getSenha() {
		return senha;
	}

	public void setSenha(String senha) {
		this.senha = senha;
	}

	public boolean isAtivo() {
		return ativo;
	}

	public void setAtivo(boolean ativo) {
		this.ativo = ativo;
	}
}
