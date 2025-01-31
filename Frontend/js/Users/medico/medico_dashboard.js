
const baixaMedicas = [
  { id: 1, pacienteId: 123, setor: "Public", dataEmissao: "2025-01-01", descricao: "A test description", medico:{ nome: "Artur Fernandes"}, diagnostico: "Hipertensão Arterial", recomendacoes: "Paciente diagnosticado com hipertensão arterial primária. Recomenda-se monitorização regular da pressão arterial, prática de atividade física moderada e dieta com baixo teor de sódio." },
  { id: 2, pacienteId: 123, setor: "Private", dataEmissao: "2025-02-01", descricao: "Another test description", medico:{ nome: "Manuel Costa"}, diagnostico: "Diabetes Tipo 2", recomendacoes: "Paciente diagnosticado com diabetes mellitus tipo 2. Recomenda-se controlo rigoroso dos níveis de glicose no sangue, uma dieta equilibrada com baixo índice glicémico e exercício físico regular." },
  { id: 3, pacienteId: 123, setor: "Public", dataEmissao: "2025-03-15", descricao: "Descrição exemplo", medico: { nome: "Carla Silva" }, diagnostico: "Asma", recomendacoes: "Paciente diagnosticado com asma. Recomenda-se o uso de inaladores prescritos e evitar exposição a alérgenos." },
  { id: 4, pacienteId: 123, setor: "Private", dataEmissao: "2025-04-10", descricao: "Exemplo de descrição", medico: { nome: "João Pereira" }, diagnostico: "Insuficiência Cardíaca", recomendacoes: "Paciente diagnosticado com insuficiência cardíaca. Recomenda-se acompanhamento cardiológico regular e uso dos medicamentos prescritos." },
  { id: 5, pacienteId: 123, setor: "Public", dataEmissao: "2025-05-05", descricao: "Detalhes sobre a consulta", medico: { nome: "Ana Sousa" }, diagnostico: "Depressão", recomendacoes: "Paciente diagnosticado com depressão. Recomenda-se acompanhamento psicológico e possível medicação conforme orientação médica." },
  { id: 6, pacienteId: 123, setor: "Private", dataEmissao: "2025-06-20", descricao: "Descrição médica", medico: { nome: "Ricardo Neves" }, diagnostico: "Osteoartrite", recomendacoes: "Paciente diagnosticado com osteoartrite. Recomenda-se fisioterapia e uso de anti-inflamatórios quando necessário." },
  { id: 7, pacienteId: 123, setor: "Public", dataEmissao: "2025-07-25", descricao: "Notas de consulta", medico: { nome: "Helena Costa" }, diagnostico: "Gripe", recomendacoes: "Paciente diagnosticado com gripe. Recomenda-se repouso, hidratação e medicação sintomática." },
  { id: 8, pacienteId: 123, setor: "Private", dataEmissao: "2025-08-15", descricao: "Informações do paciente", medico: { nome: "Miguel Tavares" }, diagnostico: "Sinusite", recomendacoes: "Paciente diagnosticado com sinusite. Recomenda-se antibióticos e descongestionantes conforme necessidade." },
  { id: 9, pacienteId: 123, setor: "Public", dataEmissao: "2025-09-10", descricao: "Observação clínica", medico: { nome: "Diana Monteiro" }, diagnostico: "Enxaqueca", recomendacoes: "Paciente diagnosticado com enxaqueca. Recomenda-se evitar gatilhos conhecidos e o uso de medicação específica." },
  { id: 10, pacienteId: 123, setor: "Private", dataEmissao: "2025-10-01", descricao: "Consulta de rotina", medico: { nome: "Fábio Lopes" }, diagnostico: "Hipotireoidismo", recomendacoes: "Paciente diagnosticado com hipotireoidismo. Recomenda-se reposição hormonal com levotiroxina." },
  { id: 11, pacienteId: 123, setor: "Public", dataEmissao: "2025-11-20", descricao: "Resultados de exames", medico: { nome: "Paula Marques" }, diagnostico: "Anemia", recomendacoes: "Paciente diagnosticado com anemia. Recomenda-se suplementação de ferro e dieta rica em ferro." },
  { id: 12, pacienteId: 123, setor: "Private", dataEmissao: "2025-12-05", descricao: "Queixa do paciente", medico: { nome: "Nuno Ferreira" }, diagnostico: "Colesterol Elevado", recomendacoes: "Paciente diagnosticado com colesterol elevado. Recomenda-se dieta equilibrada, exercício e medicação se necessário." },
  { id: 13, pacienteId: 123, setor: "Public", dataEmissao: "2025-01-15", descricao: "Informações adicionais", medico: { nome: "Mariana Duarte" }, diagnostico: "Hiperglicemia", recomendacoes: "Paciente diagnosticado com hiperglicemia. Recomenda-se monitorização da glicemia e ajuste da dieta." },
  { id: 14, pacienteId: 123, setor: "Private", dataEmissao: "2025-02-28", descricao: "Histórico médico", medico: { nome: "Tiago Almeida" }, diagnostico: "Insônia", recomendacoes: "Paciente diagnosticado com insônia. Recomenda-se higiene do sono e terapia cognitivo-comportamental." },
  { id: 15, pacienteId: 123, setor: "Public", dataEmissao: "2025-03-10", descricao: "Consulta de especialidade", medico: { nome: "Isabel Rodrigues" }, diagnostico: "Alergia Sazonal", recomendacoes: "Paciente diagnosticado com alergia sazonal. Recomenda-se uso de anti-histamínicos e evitar exposição a alérgenos." },
  { id: 16, pacienteId: 123, setor: "Private", dataEmissao: "2025-04-25", descricao: "Consulta de acompanhamento", medico: { nome: "Luís Martins" }, diagnostico: "Dermatite Atópica", recomendacoes: "Paciente diagnosticado com dermatite atópica. Recomenda-se hidratação constante da pele e uso de cremes tópicos prescritos." },
  { id: 17, pacienteId: 123, setor: "Public", dataEmissao: "2025-05-12", descricao: "Detalhes clínicos", medico: { nome: "Clara Nogueira" }, diagnostico: "Hipotensão", recomendacoes: "Paciente diagnosticado com hipotensão. Recomenda-se aumentar o consumo de sal e líquidos." },
  { id: 18, pacienteId: 123, setor: "Private", dataEmissao: "2025-06-18", descricao: "Consulta de urgência", medico: { nome: "Pedro Campos" }, diagnostico: "Fratura", recomendacoes: "Paciente diagnosticado com fratura. Recomenda-se imobilização e acompanhamento ortopédico." },
  { id: 19, pacienteId: 123, setor: "Public", dataEmissao: "2025-07-05", descricao: "Revisão médica", medico: { nome: "Vera Figueiredo" }, diagnostico: "Hipertiroidismo", recomendacoes: "Paciente diagnosticado com hipertiroidismo. Recomenda-se controle com medicamentos antitireoidianos." },
  { id: 20, pacienteId: 123, setor: "Private", dataEmissao: "2025-08-22", descricao: "Observação de sintomas", medico: { nome: "André Vieira" }, diagnostico: "Doença Renal Crônica", recomendacoes: "Paciente diagnosticado com doença renal crônica. Recomenda-se dieta específica e acompanhamento nefrológico regular." },
  { id: 21, pacienteId: 123, setor: "Public", dataEmissao: "2025-09-10", descricao: "Informações do paciente", medico: { nome: "Sara Mendes" }, diagnostico: "Infecção Urinária", recomendacoes: "Paciente diagnosticado com infecção urinária. Recomenda-se uso de antibióticos e aumento da ingestão de líquidos." },
  { id: 22, pacienteId: 123, setor: "Private", dataEmissao: "2025-10-05", descricao: "Consulta pré-operatória", medico: { nome: "Rafael Moreira" }, diagnostico: "Varizes", recomendacoes: "Paciente diagnosticado com varizes. Recomenda-se uso de meias de compressão e possível intervenção cirúrgica." },
  { id: 23, pacienteId: 123, setor: "Public", dataEmissao: "2025-11-20", descricao: "Acompanhamento pós-cirúrgico", medico: { nome: "Patrícia Gomes" }, diagnostico: "Cálculos Biliares", recomendacoes: "Paciente diagnosticado com cálculos biliares. Recomenda-se acompanhamento gastroenterológico." },
  { id: 24, pacienteId: 123, setor: "Private", dataEmissao: "2025-12-15", descricao: "Consulta preventiva", medico: { nome: "José Antunes" }, diagnostico: "Estenose Espinhal", recomendacoes: "Paciente diagnosticado com estenose espinhal. Recomenda-se fisioterapia e possível intervenção cirúrgica." },
  { id: 25, pacienteId: 123, setor: "Public", dataEmissao: "2025-01-01", descricao: "Consulta geral", medico: { nome: "Rita Carvalho" }, diagnostico: "Síndrome do Túnel do Carpo", recomendacoes: "Paciente diagnosticado com síndrome do túnel do carpo. Recomenda-se uso de talas e ajuste ergonômico no local de trabalho." }
];

const medicoData = {nMedico:"746537647", especialidade:"oftalmologia", userData:{nome:"João Silva", nTelefone:963546534, dataNascimento:"01/12/1996", numeroCC:253635645, sexo:"Masculino", morada:"Rua da Liberdade, 123"}};


function getBaixas(pageNumber, pageSize) {
  return new Promise(resolve => {
    setTimeout(() => {
      resolve(baixaMedicas.slice(0, pageSize)); 
    }, 500);
  });
}

function loadBaixasToTable() {
  const pageNumber = 1;  
  const pageSize = 10;
  
  getBaixas(pageNumber, pageSize)
    .then(baixas => {
      const baixasContainer = document.getElementById("baixaCardBox");
      baixasContainer.innerHTML = "";

      const table = document.createElement("table");
      table.classList.add("table", "table-hover", "table-striped", "table-bordered", "table-responsive"); 
      
      const tableHead = `
        <thead>
          <tr>
            <th>Data de Emissão</th>
            <th>Médico</th>
            <th>Diagnóstico</th>
            <th>Recomendações</th>
            <th>Ações</th>
          </tr>
        </thead>
      `;
      table.innerHTML = tableHead;

      const tableBody = document.createElement("tbody");
      tableBody.innerHTML = ""; 

      baixas.forEach(baixa => {
        const row = document.createElement("tr");
        const tdDataEmissao = document.createElement("td");
        tdDataEmissao.textContent = baixa.dataEmissao;
        tdDataEmissao.onclick = () => openBaixaModal(baixa.id);
        row.appendChild(tdDataEmissao);

        const tdMedico = document.createElement("td");
        tdMedico.textContent = baixa.medico.nome;
        tdMedico.onclick = () => openBaixaModal(baixa.id);
        row.appendChild(tdMedico);

        const tdDiagnostico = document.createElement("td");
        tdDiagnostico.textContent = baixa.diagnostico;
        tdDiagnostico.onclick = () => openBaixaModal(baixa.id);
        row.appendChild(tdDiagnostico);

        const tdRecomendacoes = document.createElement("td");
        tdRecomendacoes.textContent = baixa.recomendacoes;
        tdRecomendacoes.onclick = () => openBaixaModal(baixa.id);
        row.appendChild(tdRecomendacoes);

        const tdAcoes = document.createElement("td");
        const updateButton = document.createElement("button");
        updateButton.classList.add("btn", "btn-outline-success", "m-2");
        updateButton.style.border = ".5px solid rgba(0, 150, 0, 0.4)";
        updateButton.textContent = "Corrigir";
        updateButton.onclick = () => openBaixaModalUpdate(baixa.id);
        tdAcoes.appendChild(updateButton);
        row.appendChild(tdAcoes);

        tableBody.appendChild(row);
      });
      table.appendChild(tableBody);
      baixasContainer.appendChild(table);
    })
    .catch(error => console.log("Error loading baixas:", error));
}

function emitirBaixa() {
  const modal = new bootstrap.Modal(document.getElementById("baixaModal"),{ backdrop: 'static', keyboard: false });
  document.getElementById("baixaModalLabel").textContent = "Emitir Nova Baixa";
  document.querySelector("#baixaModal .modal-body").innerHTML = `
    <form>
      <div class="mb-3">
        <label for="dataEmissao" class="form-label">Data de Emissão</label>
        <input type="date" class="form-control" id="dataEmissao">
      </div>
      <div class="mb-3">
        <label for="medico" class="form-label">Médico</label>
        <input type="text" class="form-control" id="medico">
      </div>
      <div class="mb-3">
        <label for="diagnostico" class="form-label">Diagnóstico</label>
        <textarea class="form-control" id="diagnostico" rows="3"></textarea>
      </div>
      <div class="text-end">
        <button type="submit" class="btn btn-outline-success" style="width:15%">Emitir</button>
      </div>
    </form>
  `;
  modal.show();
}

function openBaixaModal(id) {
  const baixa = baixaMedicas.find(b => b.id === id);

  if (baixa) {
    document.getElementById("baixaModalLabel").textContent = `Resumo de Saúde`;
    document.querySelector("#baixaModal .modal-body").innerHTML = `
      <h6 class="card-title">Ato: ${baixa.id}</h6>
      <p class="card-text">Data de emissão: ${baixa.dataEmissao}</p>
      <p class="card-text">Médico: ${baixa.medico.nome}</p>
      <p class="card-text">Diagnóstico: ${baixa.diagnostico}</p>
      <p class="card-text">Recomendações: ${baixa.recomendacoes}</p>
    `;

    const modal = new bootstrap.Modal(document.getElementById("baixaModal"),
  {backdrop: 'static', keyboard: false });
    modal.show();
  } else {
    console.error("Baixa not found for ID:", id);
  }
}

function openBaixaModalUpdate(id) {
  const baixa = baixaMedicas.find(b => b.id === id);

  if (baixa) {
    document.getElementById("baixaModalLabel").textContent = `Atualizar Dados de Saúde`;
    document.querySelector("#baixaModal .modal-body").innerHTML = `
      <form id="updateBaixaForm" class="needs-validation" novalidate>
        <div class="mb-3">
          <label for="atoId" class="form-label">Ato</label>
          <input type="text" class="form-control" id="atoId" name="atoId" value="${baixa.id}" readonly>
        </div>
        
        <div class="mb-3">
          <label for="dataEmissao" class="form-label">Data de Emissão</label>
          <input type="date" class="form-control" id="dataEmissao" name="dataEmissao" value="${baixa.dataEmissao}" required>
        </div>
        
        <div class="mb-3">
          <label for="medicoNome" class="form-label">Médico</label>
          <input type="text" class="form-control" id="medicoNome" name="medicoNome" value="${baixa.medico.nome}" required>
        </div>
        
        <div class="mb-3">
          <label for="diagnostico" class="form-label">Diagnóstico</label>
          <textarea class="form-control" id="diagnostico" name="diagnostico" rows="3" required>${baixa.diagnostico}</textarea>
        </div>
        
        <div class="mb-3">
          <label for="recomendacoes" class="form-label">Recomendações</label>
          <textarea class="form-control" id="recomendacoes" name="recomendacoes" rows="3" required>${baixa.recomendacoes}</textarea>
        </div>
        
        <div class="text-end">
          <button type="submit" class="btn btn-outline-success">Guardar Alterações</button>
        </div>
      </form>
    `;
    const modal = new bootstrap.Modal(document.getElementById("baixaModal"),{backdrop: 'static', keyboard: false });
    modal.show();
  } else {
    console.error("Baixa not found for ID:", id);
  }
}

function displayMedicoData() {
  const medicoDataContainer = document.getElementById("medicoDataContainer");
  const medicoDataDiv = document.createElement('div');
  medicoDataDiv.innerHTML = `
   <div class="userDataDisplayDiv">
      <div>
        <h4>Dados do Utilizador</h4>
        <div><span>Nome:</span> ${medicoData.userData.nome}</div>
        <div><span>Data de Nascimento:</span> ${medicoData.userData.dataNascimento}</div>
        <div><span>Número CC:</span> ${medicoData.userData.numeroCC}</div>
        <div><span>Sexo:</span> ${medicoData.userData.sexo}</div>
      </div>
      
      <div>
        <h4>Dados do medico</h4>
        <div><span>Número médico:</span> ${medicoData.nMedico}</div>
        <div><span>Especialidade:</span> ${medicoData.especialidade}</div>
      </div>
    </div>
  `

  medicoDataContainer.appendChild(medicoDataDiv);
};


document.addEventListener("DOMContentLoaded", function() {
  displayMedicoData();
});