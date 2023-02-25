# IEML

This documents briefly walks over how to read the Information Economy MetaLanguage (IEML) in it's text form.

## Sentences

### Node

A sentence, possible containing all nine roles.

[Reference](https://intlekt.io/phrases/)

```
@node
    fr:conscience -
    en:awareness -
    (
    0 #mental health symptoms,
    1 #personal memory,
    2 #awareness
    ).
```

### Auxilaries

```
@auxiliary 
	en:has as its operation         // english identifier
	role:4                          // on what role in @node this auxiliray can be used
	"E:.d.a.-".
```

Used via `*`.

### Inflections

```
@inflection 
	fr:processus achevé
	en:process completed
    class:VERB
	"E:U:.-t.o.-'".
```

Used via `~`. Example:

```
@node
	fr:maturité personnelle
	en:personal maturity
	(
	0 ~ process completed #personal maturation
	).

```

## Paradigms

A sentence with one or more subscitution groups (variables). Just like OR-types in F#

```ieml
@paranode
fr:paradigme des symptômes liés à la cognition
en:paradigm of symptoms related to cognition
1d:/#/2
(
0 #mental health symptoms,
1 #cognitive dimension,
2 {#language ; #reasoning ; #sensorimotor abilities}
).
```

```
@rootparadigm type:auxiliary "E:.+O:O:.d.a.-".
```

## Links

@link

@function 

## Tables

```
@table
    #directory of mental states for psychiatry -> psychic functions paradigm
    #Psychic autonomy -> paradigm of the symptoms related to psychic autonomy
    #self-representation - -> paradigm of symptoms related to self-representation
    #self-repair - -> paradigm of symptoms related to self-repair
    #self-regulation - -> paradigm of symptoms related to self-regulation
    #Subjectivation -> paradigm of symptoms related to subjectivation
    #self-reference - -> paradigm of symptoms related to self-reference
    #inter-subjectivity - -> paradigm of symptoms related to the inter-subjectivity
    #thought - -> paradigm of symptoms related to thought
    #Emotion -> paradigm of symptoms related to emotion 
    #emotional quality - -> paradigm of symptoms related to emotional quality
    #emotional strength - -> paradigm of symptoms related to emotional strength
    #emotional consistency - -> paradigm of symptoms related to emotional consistency
    #Cognition -> paradigm of symptoms related to cognition
    #language - -> paradigm of symptoms related to language
    #reasoning - -> paradigm of symptoms related to reasoning
    #sensori-motricity - -> paradigm of symptoms related to sensori-motricity
    #Personal memory -> paradigm of symptoms related to the personal memory
    #awareness - -> paradigm of symptoms related to awareness
    #intermediary memory - -> paradigm of symptoms related to the intermediary memory
    #long term memory - -> paradigm of symptoms related to the long term memory .
```