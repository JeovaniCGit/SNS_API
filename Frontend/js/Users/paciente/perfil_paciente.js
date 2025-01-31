 const pacienteData = {profissao: "Padeiro", entidadePatronal: "Padaria do bairro", numeroSNS: 647536546};
 const userData = {nome: "João Silva", nTelefone: 963546534, dataNascimento: "01/12/1996", numeroCC: 253635645, sexo: "Masculino", morada: "Rua da Liberdade, 123"};

 document.getElementById('displayNome').textContent = userData.nome;
 document.getElementById('displayNTelefone').textContent = userData.nTelefone;
 document.getElementById('displayDataNascimento').textContent = userData.dataNascimento;
 document.getElementById('displayNumeroCC').textContent = userData.numeroCC;
 document.getElementById('displaySexo').textContent = userData.sexo;
 document.getElementById('displayMorada').textContent = userData.morada;
 document.getElementById('displayProfissao').textContent = pacienteData.profissao;
 document.getElementById('displayEntidadePatronal').textContent = pacienteData.entidadePatronal;
 document.getElementById('displayNumeroSNS').textContent = pacienteData.numeroSNS;

 function formatDate(dateString) {
  const [day, month, year] = dateString.split("/"); // Split the DD/MM/YYYY string
  return `${year}-${month}-${day}`; // Return in YYYY-MM-DD format
}


function displayUpdateDataForm() {
  const container = document.querySelector(".profile-container");
  const main = document.getElementsByTagName("main");
  container.textContent = "";
  container.innerHTML = `
  <h3 class="d-inline-block display-5 titleIndex mb-4">Dados do Utilizador</h3>
  <div class="d-flex flex-row updatePacienteFormContainer" style="width: 100%;">
    <div>
      <form id="pacienteForm" class="needs-validation" novalidate>
          <div class="mb-3">
            <label for="nome" class="form-label">Nome</label>
            <input type="text" class="form-control" id="nome" name="nome" value="${userData.nome}" required>
          </div>
      
          <div class="mb-3">
            <label for="nTelefone" class="form-label">Número de Telefone</label>
            <input type="text" class="form-control" id="nTelefone" name="nTelefone" value="${userData.nTelefone}" required>
          </div>
      
          <div class="mb-3">
            <label for="dataNascimento" class="form-label">Data de Nascimento</label>
            <input type="date" class="form-control" id="dataNascimento" name="dataNascimento" value="${formatDate(userData.dataNascimento)}" required>
          </div>
      
          <div class="mb-3">
            <label for="numeroCC" class="form-label">Número de CC</label>
            <input type="number" class="form-control" id="numeroCC" name="numeroCC" value="${userData.numeroCC}" required>
          </div>
      
          <div class="mb-3">
            <label for="sexo" class="form-label">Sexo</label>
            <select class="form-select" id="sexo" name="sexo" required>
              <option value="Masculino" ${userData.sexo === 'Masculino' ? 'selected' : ''}>Masculino</option>
              <option value="Feminino" ${userData.sexo === 'Feminino' ? 'selected' : ''}>Feminino</option>
            </select>
          </div>
      
          <div class="mb-3">
            <label for="morada" class="form-label">Morada</label>
            <input type="text" class="form-control" id="morada" name="morada" value="${userData.morada}" required>
          </div>
        </div>
        <div>
          <div class="mb-3">
            <label for="profissao" class="form-label">Profissão</label>
            <input type="text" class="form-control" id="profissao" name="profissao" value="${pacienteData.profissao}" required>
          </div>

          <div class="mb-3">
            <label for="entidadePatronal" class="form-label">Entidade Patronal</label>
            <input type="text" class="form-control" id="entidadePatronal" name="entidadePatronal" value="${pacienteData.entidadePatronal}" required>
          </div>

          <div class="mb-3">
            <label for="numeroSNS" class="form-label">Número SNS</label>
            <input type="number" class="form-control" id="numeroSNS" name="numeroSNS" value="${pacienteData.numeroSNS}" required>
          </div>

          <div class="text-end">
             <button type="submit" class="btn btn-outline-success" style="min-width: 8%; margin: 1.12em;">Atualizar dados</button>
          </div>
        </div>
      </form>
    </div>
  </div>
`;
}

 document.getElementById("alterarDadosBtn").addEventListener('click',displayUpdateDataForm);