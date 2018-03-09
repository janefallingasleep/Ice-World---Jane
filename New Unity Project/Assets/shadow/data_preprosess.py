


import os
import re
import csv
from nltk.corpus import stopwords
sw = set(stopwords.words('english'))

def main():
    #   import file 
    file_name = "hoodline_challenge.csv"
    input_csv = open(file_name, 'rb')
    contents = []
    reader = csv.DictReader(input_csv)
    for row in reader:
        clean_row = re.sub('[^a-zA-Z]+', ' ', row['content'])
        contents.append(clean_row.lower())
    temp = ','.join(contents)
    
    #   add stop words to the set
    sw.update(('image','com','href','utm','photo','inline','ltr','px','amp','figure','img',
        'class', 'figcaption', 'blockquote', 'iframe','target','blank','src','www','a','b',
        'c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w',
        'x','y','z','https','http','dir','href','br','li','style','font','width','margin',
        'div','height','padding','hoodline','en','lang','subheading','frameborder','nl','es',
        'uploads','ck','clktr','amazonaws','hoodwork','size','story','jpg')) 
    
    #   filtering out stop words in the corpus
    vocabulary = filter(lambda w: not w in sw, temp.split())
    output = ' '.join(vocabulary)
    output_file = open('0_contents.txt', 'w')
    output_file.write(output)
    output_file.close()

if __name__ == "__main__":
    main()