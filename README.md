Just some hacking around with WebGL and the 7digital API

The WebGl code used [Lesson 5][1] from Giles' excellent [Learning WebGl blog][2]

My aim was to pull the cover art and artist images from the 7digital API and map them to the faces of the rotating cube.  This required me to create a simple proxy for the calls to the api so that I could strip out the image urls in a JSON format and to get act as a proxy to avoid cross-domain security issues.  The proxy is extremely simple and written in in C# with Asp.Net MVC2.

Using the following querystring parameters the images on the cube will update from searching the api.

* `searchType`: can either be "artists" or "releases"
* `search`: the search string, e.g. "radiohead", "pink", "in rainbows"

_Disclaimer_ - This is the first time I've really played with javascript, so the code which is mine is ugly and probably easy to break.  Hopefully by adding to this project I can improve my skills.


  [1]: http://learningwebgl.com/blog/?p=507
  [2]: http://learningwebgl.com
  
  
  
  
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.