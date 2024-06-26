import streamlit as st
from langchain_community.vectorstores import FAISS
from langchain_openai import OpenAIEmbeddings
from langchain.prompts import PromptTemplate
from langchain_openai import ChatOpenAI
import os
from langchain_community.document_loaders import CSVLoader
from langchain_core.runnables import RunnableMap  # Importar RunnableMap

# Verificar se a variável OPENAI_API_KEY está configurada corretamente
def initialize_openai(api_key):
    os.environ['OPENAI_API_KEY'] = api_key

def generate_response(message, api_key):
    initialize_openai(api_key)
    
    loader = CSVLoader(file_path="D:\\Estudos\\PrediLang\\PrediLang.LangChain\\knowlege_base.csv")
    documents = loader.load()
    
    embeddings = OpenAIEmbeddings()
    db = FAISS.from_documents(documents, embeddings)
    
    def retrive_info(query):
        similar_response = db.similarity_search(query, k=3)
        return [doc.page_content for doc in similar_response]  # Corrigido de `page_contet` para `page_content`
    
    llm = ChatOpenAI(temperature=0, model="gpt-3.5-turbo-16k-0613")
    
    template = """
    Você é um assistente virtual voltado para auxiliar no estudo de futuros.
    Sua função será a de gerar possíveis cenários, identificar sinais fracos, tendências e incertezas.
    Posso lhe passar informações que irão auxiliar na criação de cenários, como pode ser utilizada as informações pré existentes do Chat GPT
    
    Aqui está um acontecimento que ocorreu
    {message}
    
    Aqui está uma lista de acontecimentos gerados, que pode servir como base para apresentação dos cenários criados
    {best_pratice}
    
    Escreva a melhor resposta que você poderia dar a um gestor, que com base nas suas informações irá tomar decisão estratégica.
    """
    
    prompt = PromptTemplate(
        input_variables=["message", "best_pratice"],
        template=template
    )
    
    # Encadeando a execução do prompt com o modelo de linguagem
    chain = prompt | llm
    
    best_pratice = retrive_info(message)
    response = chain.invoke({"message": message, "best_pratice": best_pratice})
    return response



# import streamlit as st
# from langchain_community.vectorstores import FAISS
# from langchain_openai import OpenAIEmbeddings
# from langchain.prompts import PromptTemplate
# from langchain_openai import ChatOpenAI
# from dotenv import load_dotenv
# import os
# from langchain_community.document_loaders import CSVLoader
# from langchain_core.runnables import RunnableMap  # Importar RunnableMap

# # load_dotenv()

# loader = CSVLoader(file_path="D:\Estudos\PrediLang\PrediLang.LangChain\knowlege_base.csv")
# documents = loader.load()

# embeddings = OpenAIEmbeddings()
# db = FAISS.from_documents(documents, embeddings)

# def retrive_info(query):
#     similar_response = db.similarity_search(query, k=3)
#     return [doc.page_content for doc in similar_response]  # Corrigido de `page_contet` para `page_content`

# llm = ChatOpenAI(temperature=0, model="gpt-3.5-turbo-16k-0613")

# template = """
# Você é um assistente virtual voltado para auxiliar no estudo de futuros.
# Sua função será a de gerar possíveis cenários, identificar sinais fracos, tendências e incertezas.
# Posso lhe passar informações que irão auxiliar na criação de cenários, como pode ser utilizada as informações pré existentes do Chat GPT

# Aqui está um acontecimento que ocorreu
# {message}

# Aqui está uma lista de acontecimentos gerados, que pode servir como base para apresentação dos cenários criados
# {best_pratice}


# Escreva a melhor resposta que você poderia dar a um gestor, que com base nas suas informações irá tomar decisão estratégica.
# """

# prompt = PromptTemplate(
#     input_variables=["message", "best_pratice"],
#     template=template
# )

# # Encadeando a execução do prompt com o modelo de linguagem
# chain = prompt | llm

# def initialize_openai(api_key):
#     os.environ['OPENAI_API_KEY'] = api_key

# def generate_response(message, api_key):
#     initialize_openai(api_key)
#     best_pratice = retrive_info(message)
#     response = chain.invoke({"message": message, "best_pratice": best_pratice})
#     return response

# # response = generate_response("""
# #     Se baseando no Brasil, quais cursos serão mais buscados pelos novos universitários?
# # """)
# # print(response)