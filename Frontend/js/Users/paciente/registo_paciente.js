document.querySelector(".registarFormBtn").addEventListener('click', OpenPacienteRegistrationForm); 

function OpenPacienteRegistrationForm() {
  const container = document.getElementById("mainContainer");
  container.innerHTML = "";
  const formContainer = document.createElement("div");
  formContainer.innerHTML = `
    <form id="userForm" class="needs-validation" novalidate>
    <div id=userFormDiv>
      <div>
        <h4 class="mt-4">Dados do Utilizador</h4>
        <!-- Nome -->
        <div class="mb-3">
          <label for="nome" class="form-label">Nome <span class="text-danger">*</span></label>
          <input type="text" class="form-control" id="nome" name="Nome" placeholder="Digite o nome" maxlength="100" required>
          <div class="invalid-feedback">O nome é obrigatório e não pode ter mais de 100 caracteres.</div>
        </div>

        <!-- Número de Telefone -->
        <div class="mb-3">
          <label for="nTelefone" class="form-label">Número de Telefone <span class="text-danger">*</span></label>
          <input type="text" class="form-control" id="nTelefone" name="NTelefone" placeholder="Ex: 923456789" pattern="^[2-9][0-9]{8}$" required>
          <div class="invalid-feedback">O número de telefone é obrigatório e deve conter 9 dígitos, começando de 2-9.</div>
        </div>

        <!-- Data de Nascimento -->
        <div class="mb-3">
          <label for="dataNascimento" class="form-label">Data de Nascimento <span class="text-danger">*</span></label>
          <input type="date" class="form-control" id="dataNascimento" name="DataNascimento" required>
          <div class="invalid-feedback">A data de nascimento é obrigatória.</div>
        </div>

        <!-- Número de CC -->
        <div class="mb-3">
          <label for="numeroCc" class="form-label">Número de CC <span class="text-danger">*</span></label>
          <input type="number" class="form-control" id="numeroCc" name="NumeroCc" placeholder="Ex: 123456789" min="100000000" max="999999999" required>
          <div class="invalid-feedback">O número de CC é obrigatório e deve ter 9 dígitos.</div>
        </div>

        <!-- Sexo -->
        <div class="mb-3">
          <label for="sexo" class="form-label">Sexo <span class="text-danger">*</span></label>
          <select class="form-select" id="sexo" name="Sexo" required>
            <option value="">Selecione o sexo</option>
            <option value="Masculino">Masculino</option>
            <option value="Feminino">Feminino</option>
          </select>
          <div class="invalid-feedback">O sexo é obrigatório e deve ser 'Masculino' ou 'Feminino'.</div>
        </div>

        <!-- Morada -->
        <div class="mb-3">
          <label for="morada" class="form-label">Morada <span class="text-danger">*</span></label>
          <input type="text" class="form-control" id="morada" name="Morada" placeholder="Digite a morada" maxlength="200" required>
          <div class="invalid-feedback">A morada é obrigatória e não pode ter mais de 200 caracteres.</div>
        </div>

        <div class="mb-3">
          <label for="tipoDeUtilizadorid" class="form-label">Tipo de Utilizador <span class="text-danger">*</span></label>
          <select class="form-select" id="tipoDeUtilizadorid" name="TipoDeUtilizadorid" required>
            <option value="">Selecione o tipo de utilizador</option>
            <option value="1">Administrador</option>
            <option value="2">Médico</option>
            <option value="3">Paciente</option>
          </select>
          <div class="invalid-feedback">O tipo de utilizador é obrigatório.</div>
        </div>

        <!-- Medico To Attribute ID -->
        <div class="mb-3">
          <label for="medicoToAttributeId" class="form-label">Médico (Opcional)</label>
          <select class="form-select" id="medicoToAttributeId" name="MedicoToAttributeId">
            <option value="">Selecione o médico (se aplicável)</option>
            <option value="101">Médico 1</option>
            <option value="102">Médico 2</option>
            <option value="103">Médico 3</option>
          </select>
        </div>
      </div>
      <div>
        <!-- Paciente Data -->
        <h4 class="mt-4">Dados do Paciente</h4>
        <div class="mb-3">
          <label for="profissao" class="form-label">Profissão</label>
          <input type="text" class="form-control" id="profissao" name="Profissao" placeholder="Digite a profissão" maxlength="50">
          <div class="invalid-feedback">A profissão não pode ter mais de 50 caracteres.</div>
        </div>

        <div class="mb-3">
          <label for="entidadePatronal" class="form-label">Entidade Patronal</label>
          <input type="text" class="form-control" id="entidadePatronal" name="EntidadePatronal" placeholder="Digite a entidade patronal" maxlength="50">
          <div class="invalid-feedback">A entidade patronal não pode ter mais de 50 caracteres.</div>
        </div>

        <div class="mb-3">
          <label for="numeroSns" class="form-label">Número SNS</label>
          <input type="number" class="form-control" id="numeroSns" name="NumeroSns" placeholder="Digite o número SNS">
        </div>
      </div>
    </div>

    <!-- Submit Button -->
    <div class="text-end">
      <button type="submit" class="btn btn-primary" style="width:15%;">Registar</button>
    </div>
  </form>
  `
  formContainer.className = "formContainer";
  container.appendChild(formContainer);
}