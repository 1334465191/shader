 
 precision highp float;
 sd  ds 

#pragma once

class Shader
{
private:
  static const string VertexShaderCode  ;
  static const string FragmentShaderCode;

private:
  GLuint m_ProgramID               ;
  GLuint m_VertexShader            ;
  GLuint m_FragmentShader          ;

  GLuint m_ProjectionMatrixLocation;
  GLuint m_ModelViewMatrixLocation ;
  GLuint m_VertexPos3DLocation     ;
  GLuint m_MultiColorLocation      ;
  GLuint m_TexCoordLocation        ;
  GLuint m_IsModulateModeLocation  ;
  GLuint m_TextureUnitLocation     ;

private:
  Shader(const Shader& t);
  Shader(Shader& t);
  Shader& operator=(const Shader& t);
  Shader& operator=(Shader&);

public:
  const GLuint GetProgramID() const { return m_ProgramID; }
  void Bind  () const { glUseProgram(m_ProgramID); }
  void UnBind() const { glUseProgram(0          ); }

  GLuint GetUniformLocation(const GLchar* nameInShader) const
  {
    return glGetUniformLocation(m_ProgramID, nameInShader);
  }
  GLuint GetAttribLocation (const GLchar* nameInShader) const
  {
    return glGetAttribLocation(m_ProgramID, nameInShader);
  }

  void setProjectionMatrix(GLfloat const* matrix)
  {
    glUniformMatrix4fv(m_ProjectionMatrixLocation, 1, GL_FALSE, matrix);
  }

  void setModelViewMatrix(GLfloat const* matrix)
  {
    glUniformMatrix4fv(m_ModelViewMatrixLocation, 1, GL_FALSE, matrix);
  }

  void EnableVertexPointer(bool enable)
  {
    if (enable)
    {
      glEnableVertexAttribArray(m_VertexPos3DLocation);
    }
    else
    {
      glDisableVertexAttribArray(m_VertexPos3DLocation);
    }
  }

  void set_uniform_matrix(const char* name, GLfloat const* matrix)
  {
    GLint matrixLocation = glGetUniformLocation(m_ProgramID, name);
    glUniformMatrix4fv(matrixLocation, 1, GL_FALSE, matrix);
  }


  void set_uniform_i(const char* name, int i)
  {
    GLint loc = glGetUniformLocation(m_ProgramID, name);
    glUniform1i(loc, i);
  }

  void set_uniform_texture(const char* name, int id, int loc)
  {
    GLint locc = glGetUniformLocation(m_ProgramID, name);
    glUniform1i(locc, loc);
    glActiveTexture(GL_TEXTURE0 + loc);
    glBindTexture(GL_TEXTURE_2D, id);
  }

public:
  Shader();
};