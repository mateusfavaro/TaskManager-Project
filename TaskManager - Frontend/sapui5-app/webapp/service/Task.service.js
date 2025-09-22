sap.ui.define([
    "tarefas/front/config/BaseUrl"
], function (BaseUrl) {
    "use strict";

    const baseUrl = BaseUrl.baseUrl;

    return {

        // GET /todos com filtros
        getAllTask: async function (params = {}) {
            const validSorts = ["title", "id"];
            const validOrders = ["asc", "desc"];

            // Monta objeto de query com validação e valores padrão
            const queryParams = {
                page: params.page > 0 ? params.page : 1,
                pageSize: params.pageSize > 0 ? params.pageSize : 10,
                sort: validSorts.includes(params.sort) ? params.sort : "title",
                order: validOrders.includes(params.order) ? params.order : "asc"
            };

            // Inclui "title" apenas se fornecido
            if (params.title && typeof params.title === "string" && params.title.trim() !== "") {
                queryParams.title = params.title.trim();
            }

            const query = new URLSearchParams(queryParams).toString();

            const response = await fetch(`${baseUrl}/api/task?${query}`);
            if (!response.ok) throw await response.json();
            return await response.json();
        }
        ,

        // GET /todos/:id
        getTaskById: async function (id) {
            const response = await fetch(`${baseUrl}/api/task/${id}`);
            if (!response.ok) throw await response.json();
            return await response.json();
        },

        // PUT /todos/:id
        putTaskStatus: async function (id, completed) {
    const response = await fetch(`${baseUrl}/api/task/${id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ completed })
    });

    if (!response.ok) {
        const errorText = await response.text();
        const errorData = errorText ? JSON.parse(errorText) : { mensagem: "Erro desconhecido" };
        console.log(errorData);
        throw new Error(errorData.mensagem || "Erro ao atualizar tarefa. Cada usuário pode ter apenas 5 tarefas incompletas");
    }

    const text = await response.text();
    return text ? JSON.parse(text) : null;
}

    };
});
