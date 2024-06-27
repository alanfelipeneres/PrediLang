import streamlit as st
from langchain_community.vectorstores import FAISS
from langchain_openai import OpenAIEmbeddings
from langchain.prompts import PromptTemplate
from langchain_openai import ChatOpenAI
import os
from langchain_community.document_loaders import CSVLoader
from langchain_core.runnables import RunnableMap  
from langchain.schema import Document

# Verificar se a variável OPENAI_API_KEY está configurada corretamente
def initialize_openai(api_key):
    os.environ['OPENAI_API_KEY'] = api_key

def generate_response(message, api_key, template, complements):
    initialize_openai(api_key)
    
    documents = [Document(page_content=row["resposta"], metadata={"pergunta": row["pergunta"]}) for row in complements]
    
    embeddings = OpenAIEmbeddings()
    db = FAISS.from_documents(documents, embeddings)
    
    def retrive_info(query):
        similar_response = db.similarity_search(query, k=3)
        return [doc.page_content for doc in similar_response]
    
    llm = ChatOpenAI(temperature=0, model="gpt-3.5-turbo-16k-0613")
    
    prompt = PromptTemplate(
        input_variables=["message", "best_pratice"],
        template=template
    )
    
    # Encadeando a execução do prompt com o modelo de linguagem
    chain = prompt | llm
    
    best_pratice = retrive_info(message)
    response = chain.invoke({"message": message, "best_pratice": best_pratice})
    return response