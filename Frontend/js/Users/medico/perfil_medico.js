const medicoData = {nMedico:"746537647", especialidade:"oftalmologia",especialidadeid: 1, userData:{nome:"João Silva", nTelefone:963546534, dataNascimento:"01/12/1996", numeroCC:253635645, sexo:"Masculino", morada:"Rua da Liberdade, 123"}};

document.getElementById('displayNome').textContent = medicoData.userData.nome;
document.getElementById('displayNTelefone').textContent = medicoData.userData.nTelefone;
document.getElementById('displayDataNascimento').textContent = medicoData.userData.dataNascimento;
document.getElementById('displayNumeroCC').textContent = medicoData.userData.numeroCC;
document.getElementById('displaySexo').textContent = medicoData.userData.sexo;
document.getElementById('displayMorada').textContent = medicoData.userData.morada;
document.getElementById('displayNMedico').textContent = medicoData.nMedico;
document.getElementById('displayEspecialidade').textContent = medicoData.especialidade;

function formatDate(dateString) {
 const [day, month, year] = dateString.split("/"); 
 return `${year}-${month}-${day}`; 
}


function displayUpdateDataForm() {
 const container = document.querySelector(".profile-container");
 const main = document.getElementsByTagName("main");
 container.textContent= "";
 container.innerHTML = `
  <h3 class="d-inline-block display-5 titleIndex mb-4">Dados do Utilizador</h3>
  <div class="d-flex flex-row updateMedicoFormContainer" style="width: 100%;">
    <div>        
      <form id="medicoForm" class="needs-validation" novalidate>
        <div class="mb-3">
          <label for="nome" class="form-label">Nome</label>
          <input type="text" class="form-control" id="nome" name="nome" value="${medicoData.userData.nome}" required>
        </div>
    
        <div class="mb-3">
          <label for="nTelefone" class="form-label">Número de Telefone</label>
          <input type="text" class="form-control" id="nTelefone" name="nTelefone" value="${medicoData.userData.nTelefone}" required>
        </div>
    
        <div class="mb-3">
          <label for="dataNascimento" class="form-label">Data de Nascimento</label>
          <input type="date" class="form-control" id="dataNascimento" name="dataNascimento" value="${formatDate(medicoData.userData.dataNascimento)}" required>
        </div>
    
        <div class="mb-3">
          <label for="numeroCC" class="form-label">Número de CC</label>
          <input type="number" class="form-control" id="numeroCC" name="numeroCC" value="${medicoData.userData.numeroCC}" required>
        </div>
    
        <div class="mb-3">
          <label for="sexo" class="form-label">Sexo</label>
          <select class="form-select" id="sexo" name="sexo" required>
            <option value="Masculino" ${medicoData.userData.sexo === 'Masculino' ? 'selected' : ''}>Masculino</option>
            <option value="Feminino" ${medicoData.userData.sexo === 'Feminino' ? 'selected' : ''}>Feminino</option>
          </select>
        </div>
    
        <div class="mb-3">
          <label for="morada" class="form-label">Morada</label>
          <input type="text" class="form-control" id="morada" name="morada" value="${medicoData.userData.morada}" required>
        </div>
    </div>
    <div>  
      <div class="mb-3">
      <label for="nmedico" class="form-label">Número Médico</label>
      <input type="text" class="form-control" id="nmedico" name="nmedico" value="${medicoData.nmedico}">
      </div>

      <div class="mb-3">
        <label for="especialidadeid" class="form-label">Especialidade ID</label>
        <input type="number" class="form-control" id="especialidadeid" name="especialidadeid" value="${medicoData.especialidadeid}">
      </div>
    
      <div class="text-end">
        <button type="submit" class="btn btn-outline-success" style="min-width: 8%; margin: 1.12em;">Atualizar dados</button>
      </div>
    </div>
    </form>
  </div>
 `
 main.appendChild(container);
}

document.getElementById("alterarDadosBtn").addEventListener('click',displayUpdateDataForm);